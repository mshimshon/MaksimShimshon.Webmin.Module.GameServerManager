using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores.Enums;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerStopDoneReducer : IReducer<LifecycleServerState, LifecycleServerStopDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStopDoneAction action)
    {
        return await Task.FromResult(state with
        {
            //SkipNextUpdates = 4
            Transition = ServerTransition.Stopping,
            Delay = 2
        });
    }
}