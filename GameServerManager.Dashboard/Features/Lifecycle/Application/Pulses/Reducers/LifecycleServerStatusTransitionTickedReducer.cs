using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusTransitionTickedReducer : IReducer<LifecycleServerState, LifecycleServerStatusTransitionTickedAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusTransitionTickedAction action)
        => await Task.FromResult(state with { TransitionTicks = state.TransitionTicks + 1 });
}
