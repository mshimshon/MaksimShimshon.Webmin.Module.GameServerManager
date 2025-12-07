using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusTransitionDoneReducer : IReducer<LifecycleServerState, LifecycleServerStatusTransitionDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusTransitionDoneAction action)
        => await Task.FromResult(state with { Delay = 8, Transition = Stores.Enums.ServerTransition.Idle, TransitionTicks =0  });
}
