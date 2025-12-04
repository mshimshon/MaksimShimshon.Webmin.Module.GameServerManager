using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Commands;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Queries;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleServerStatusPeriodicUpdateEffect : IEffect<TickerPerformerAction>
{
    private readonly IStateAccessor<LifecycleServerState> _stateAccessor;
    private readonly IMedihater _medihater;

    public LifecycleServerStatusPeriodicUpdateEffect(IStateAccessor<LifecycleServerState> stateAccessor, IMedihater medihater)
    {
        _stateAccessor = stateAccessor;
        _medihater = medihater;
    }
    public async Task EffectAsync(TickerPerformerAction action, IDispatcher dispatcher) {
        DateTime nextUpdated = _stateAccessor.State.ServerInfoLastUpdate.AddSeconds(10);
        if (nextUpdated > DateTime.UtcNow)
        {
            Console.WriteLine("Lifecycle Server Status Update Skipping (Not Time Yet).");
            return;
        }


        var exec = new GetServerStatusQuery();
        var serverInfo = await _medihater.Send(exec);

        var dispatchPrep = dispatcher.Prepare<LifecycleServerStatusUpdateDoneAction>();
        dispatchPrep.With(p => p.ServerInfo, serverInfo);
        await dispatchPrep.DispatchAsync();
    }
}
