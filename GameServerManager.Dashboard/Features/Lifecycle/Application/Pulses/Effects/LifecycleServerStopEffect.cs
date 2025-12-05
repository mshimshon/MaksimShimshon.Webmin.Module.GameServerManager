using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Commands;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleServerStopEffect : IEffect<LifecycleServerStopAction>
{
    private readonly IStateAccessor<LifecycleServerState> _stateAccessor;
    private readonly IMedihater _medihater;

    public LifecycleServerStopEffect(IStateAccessor<LifecycleServerState> stateAccessor, IMedihater medihater)
    {
        _stateAccessor = stateAccessor;
        _medihater = medihater;
    }
    public async Task EffectAsync(LifecycleServerStopAction action, IDispatcher dispatcher)
    {
        var exec = new ExecStopServerCommand();
        await _medihater.Send(exec);

        var dispatchPrep = dispatcher.Prepare<LifecycleServerStopDoneAction>();
        await dispatchPrep.DispatchAsync();
    }
}
