using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Reducers;

public class WebminInitializeModuleDoneReducer : IReducer<WebminModuleFrameState, WebminInitializeModuleDoneAction>
{
    public async Task<WebminModuleFrameState> ReduceAsync(WebminModuleFrameState state, WebminInitializeModuleDoneAction action) => 
        await Task.FromResult(state with {
            ModuleName = action.ModuleName,
            IsReady = true,
            IsLoading = false, 
            ErrorMessage = action.ErrorMessage, 
            ErrorCode = action.ErrorCode
        });
}
