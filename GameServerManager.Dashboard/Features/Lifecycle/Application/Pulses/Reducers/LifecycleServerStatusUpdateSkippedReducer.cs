using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusUpdateSkippedReducer : IReducer<LifecycleServerState, LifecycleServerStatusUpdateSkippedAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusUpdateSkippedAction action)
        => await Task.FromResult(state with { 
            SkipNextUpdates = state.SkipNextUpdates - 1 <= 0 ? 0 : state.SkipNextUpdates - 1 
        });
}
