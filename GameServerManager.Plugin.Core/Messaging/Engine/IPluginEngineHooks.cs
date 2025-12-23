using Microsoft.AspNetCore.Components;

namespace GameServerManager.Plugin.Core.Messaging.Engine;

public interface IPluginEngineHooks
{
    public EventHandler<RenderFragment> Menu { get; set; }

}
