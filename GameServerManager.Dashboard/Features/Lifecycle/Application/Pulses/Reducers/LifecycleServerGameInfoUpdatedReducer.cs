using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerGameInfoUpdatedReducer : IReducer<LifecycleGameInfoState, LifecycleServerGameInfoUpdatedAction>
{
    public async Task<LifecycleGameInfoState> ReduceAsync(LifecycleGameInfoState state, LifecycleServerGameInfoUpdatedAction action)
        => await Task.FromResult(state with { GameInfo = action.GameInfo }); 
}
