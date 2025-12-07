using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerSystemInfoUpdatedReducer : IReducer<LifecycleSystemState, LifecycleServerSystemInfoUpdatedAction>
{
    public async Task<LifecycleSystemState> ReduceAsync(LifecycleSystemState state, LifecycleServerSystemInfoUpdatedAction action)
        => await Task.FromResult(state with { SystemInfo = action.SystemInfo });
}
