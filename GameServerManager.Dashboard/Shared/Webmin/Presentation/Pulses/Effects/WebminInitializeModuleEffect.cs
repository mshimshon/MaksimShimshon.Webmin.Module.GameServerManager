using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Effects;

public class WebminInitializeModuleEffect : IEffect<WebminInitializeModuleAction>
{
    private readonly IWebAssemblyHostEnvironment _webAssemblyHostEnvironment;

    public WebminInitializeModuleEffect(IWebAssemblyHostEnvironment webAssemblyHostEnvironment)
    {
        _webAssemblyHostEnvironment = webAssemblyHostEnvironment;
    }
    public async Task EffectAsync(WebminInitializeModuleAction action, IDispatcher dispatcher){
        var prepper = dispatcher.Prepare<WebminInitializeModuleDoneAction>();
        prepper.With(p => p.ModuleName, action.ModuleName);
        Console.WriteLine($"Debugger: {System.Diagnostics.Debugger.IsAttached}");
        if (_webAssemblyHostEnvironment.IsDevelopment())
        {
            prepper.With(p => p.ErrorCode, "WeminDebugBlocked");
            prepper.With(p => p.ErrorMessage, "This Module is not available while in debug mode.");
        }

        await prepper.DispatchAsync();
    }
}
