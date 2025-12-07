using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleServerStatusTransitionEffect : IEffect<LifecycleServerStatusUpdateDoneAction>
{
    private readonly IStateAccessor<LifecycleServerState> _stateAccessor;
    private readonly IDispatcher _dispatcher;

    public LifecycleServerStatusTransitionEffect(IStateAccessor<LifecycleServerState> stateAccessor, IDispatcher dispatcher)
    {
        _stateAccessor = stateAccessor;
        _dispatcher = dispatcher;
    }
    public async Task EffectAsync(LifecycleServerStatusUpdateDoneAction action, IDispatcher dispatcher)
    {
        if (_stateAccessor.State.Transition == Stores.Enums.ServerTransition.Idle || _stateAccessor.State.ServerInfo == default) 
            return;

        // Cancel
        if(_stateAccessor.State.TransitionTicks >= 60)
            await _dispatcher.Prepare<LifecycleServerStatusTransitionDoneAction>().DispatchAsync();

        var (transition, status) = (_stateAccessor.State.Transition, _stateAccessor.State.ServerInfo.Status);

        if ((transition == Stores.Enums.ServerTransition.Starting && status == Domain.Enums.Status.Running) ||
            (transition == Stores.Enums.ServerTransition.Stopping && status == Domain.Enums.Status.Stopped))
            await _dispatcher.Prepare<LifecycleServerStatusTransitionDoneAction>().DispatchAsync();
        else if ((transition == Stores.Enums.ServerTransition.Starting && status == Domain.Enums.Status.Stopped) ||
                 (transition == Stores.Enums.ServerTransition.Stopping && status == Domain.Enums.Status.Running))
            await _dispatcher.Prepare<LifecycleServerStatusTransitionTickedAction>().DispatchAsync();


    }
}
