using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStopDoneReducer : IReducer<LifecycleServerState, LifecycleServerStopDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStopDoneAction action)
    {
        return await Task.FromResult(state with
        {
            SkipNextUpdates = 4
        });
    }
}