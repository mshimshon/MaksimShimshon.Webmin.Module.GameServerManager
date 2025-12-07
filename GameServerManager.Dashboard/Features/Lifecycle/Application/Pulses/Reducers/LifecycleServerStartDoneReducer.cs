using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Reducers;

public class LifecycleServerStartDoneReducer : IReducer<LifecycleServerState, LifecycleServerStartDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStartDoneAction action) {
        return await Task.FromResult(state with
        {
             //SkipNextUpdates = 4
              Transition = Application.Pulses.Stores.Enums.ServerTransition.Starting, 
            Delay = 2
        });
    }
}
