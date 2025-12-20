using GameServerManager.Core.Shared.Webmin.Presentation.Pulses.Actions;
using MudBlazor;
using StatePulse.Net;

namespace GameServerManager.Core.Shared.Webmin.Presentation.Pulses.Effects;

public class WebminInitializeModuleEffect : IEffect<WebminInitializeModuleAction>
{

    public WebminInitializeModuleEffect()
    {
    }
    public async Task EffectAsync(WebminInitializeModuleAction action, IDispatcher dispatcher){
        var prepper = dispatcher.Prepare<WebminInitializeModuleDoneAction>();
        prepper.With(p => p.ModuleName, action.ModuleName);
        Console.WriteLine($"Debugger: {System.Diagnostics.Debugger.IsAttached}");


        await prepper.DispatchAsync();
    }
}
