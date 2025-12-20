using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores.Enums;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusTransitionDoneReducer : IReducer<LifecycleServerState, LifecycleServerStatusTransitionDoneAction>
{
    private readonly IEventBus _eventBus;

    public LifecycleServerStatusTransitionDoneReducer(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusTransitionDoneAction action)
    {
        if (state.Transition == ServerTransition.Starting)
        {
            if (state.ServerInfo == default || state.ServerInfo.Status != Domain.Enums.Status.Running)
                await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStartFailed));
            else if (state.ServerInfo != default && state.ServerInfo.Status == Domain.Enums.Status.Running)
                await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStartSuccess));

            await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStopFinish));
        }
        else if (state.Transition == ServerTransition.Stopping)
        {
            if(state.ServerInfo == default || state.ServerInfo.Status != Domain.Enums.Status.Stopped)
                await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStopFailed));
            else if (state.ServerInfo != default && state.ServerInfo.Status == Domain.Enums.Status.Stopped)
                await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStopSuccess));

            await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStopFinish));
        }
        var nstate = state with { Delay = 8, Transition = ServerTransition.Idle, TransitionTicks = 0 };
        return nstate;
    }
}
