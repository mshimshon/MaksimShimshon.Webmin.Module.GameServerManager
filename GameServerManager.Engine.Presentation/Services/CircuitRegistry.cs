using GameServerManager.Engine.Infrastructure.Circuit;
using Microsoft.AspNetCore.Components.Server.Circuits;
namespace GameServerManager.Engine.Presentation.Services;

public sealed class CircuitRegistry : CircuitHandler, ICircuitControl
{
    private static List<CircuitIdentityDto> _circuits = new();
    private static readonly object _lock = new();
    private CircuitIdentityDto _currentCircuit = new();


    public IReadOnlyCollection<CircuitIdentityDto> GetActiveCircuits()
    {
        lock (_lock)
        {
            return _circuits.Where(p => p.IsLinkUp && p.ServiceProvider != default).ToList().AsReadOnly();
        }
    }
    internal void SelfCircuitRegistration(IServiceProvider serviceProvider)
    {
        _currentCircuit.ServiceProvider = serviceProvider;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken token)
    {

        lock (_lock)
        {

            if (!_circuits.Any(p => p.Id == circuit.Id))
            {
                _currentCircuit = _currentCircuit with { Id = circuit.Id };
                _circuits.Add(_currentCircuit);

            }
        }
        return Task.CompletedTask;
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken token)
    {
        lock (_lock)
        {
            if (_circuits.Any(p => p.Id == circuit.Id))
                _circuits.Remove(_currentCircuit);
        }
        return Task.CompletedTask;
    }

    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _currentCircuit.IsLinkUp = true;
        }
        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _currentCircuit.IsLinkUp = false;
        }
        return Task.CompletedTask;
    }
}



