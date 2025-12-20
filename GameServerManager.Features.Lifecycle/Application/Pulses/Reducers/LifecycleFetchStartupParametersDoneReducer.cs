using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleFetchStartupParametersDoneReducer : IReducer<LifecycleGameInfoState, LifecycleFetchStartupParametersDoneAction>
{
    public async Task<LifecycleGameInfoState> ReduceAsync(LifecycleGameInfoState state, LifecycleFetchStartupParametersDoneAction action)
        => await Task.FromResult(state with { StartupParameters = action.StartupParameters, SavedParametersLoaded = true });
}
