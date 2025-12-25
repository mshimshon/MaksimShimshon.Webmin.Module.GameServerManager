using GameServerManager.Engine.Domain.Plugin.Entites;
using LunaticPanel.Core;

namespace LunaticPanel.Engine.Presentation.Services.Plugin;

public sealed record PluginItem(
        IPlugin Entry,
        PluginEntity Plugin
    )
{

}
