using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores.Enums;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusTransitionDoneReducer : IReducer<LifecycleServerState, LifecycleServerStatusTransitionDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusTransitionDoneAction action)
    {

        var nstate = state with { Delay = 8, Transition = ServerTransition.Idle, TransitionTicks = 0 };
        return nstate;
    }
}
