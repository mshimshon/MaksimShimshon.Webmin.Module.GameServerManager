using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStatusUpdateDoneReducer : IReducer<LifecycleServerState, LifecycleServerStatusUpdateDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStatusUpdateDoneAction action)
        => await Task.FromResult(state with { ServerInfoLastUpdate = DateTime.UtcNow, ServerInfo = action.ServerInfo });
}
