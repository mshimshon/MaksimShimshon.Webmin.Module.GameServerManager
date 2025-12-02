using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Reducers;

public class LifecycleServerStartDoneReducer : IReducer<LifecycleServerState, LifecycleServerStartDoneAction>
{
    public async Task<LifecycleServerState> ReduceAsync(LifecycleServerState state, LifecycleServerStartDoneAction action) {
        Console.WriteLine("Server Launch Completed, State Updated!");
        return await Task.FromResult(state with
        {
            IsRunning = action.IsStarted,
            LastRunErrorCode = action.ErrorCode,
            LastRunErrorMessage = action.ErrorMessage
        });
    }
}
