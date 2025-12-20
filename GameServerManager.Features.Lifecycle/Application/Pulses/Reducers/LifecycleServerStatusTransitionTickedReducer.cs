using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusTransitionTickedReducer : IReducer<LifecycleServerState, LifecycleServerStatusTransitionTickedAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusTransitionTickedAction action)
        => await Task.FromResult(state with { TransitionTicks = state.TransitionTicks + 1 });
}
