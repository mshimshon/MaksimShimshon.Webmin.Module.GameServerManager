using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine.Services.CircuitControl;

public sealed class CircuitRegistry : CircuitHandler
{
    private static List<CircuitIdentity> _circuits = new();
    private static readonly object _lock = new();
    private CircuitIdentity _currentCircuit = new();



    public void SelfCircuitRegistration(IServiceProvider serviceProvider)
    {
        _currentCircuit.ServiceProvider = serviceProvider;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken token)
    {

        lock (_lock)
        {
            
            if (!_circuits.Any(p=>p.Id == circuit.Id))
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
            if (_circuits.Any(p=>p.Id == circuit.Id))
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


    
