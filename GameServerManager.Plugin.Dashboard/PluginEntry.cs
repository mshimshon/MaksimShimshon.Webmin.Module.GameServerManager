using GameServerManager.Plugin.Core;
using GameServerManager.Plugin.Core.Plugin.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Plugin.Dashboard;

internal class PluginEntry : IPlugin<PluginEntry>
{

    public IReadOnlyDictionary<PluginMetadataType, string> GetMetadata() =>
        new Dictionary<PluginMetadataType, string>() {
            { PluginMetadataType.DisplayName, "Dashboard (Main)" },
            { PluginMetadataType.Author, "Maksim Shimshon" },
            { PluginMetadataType.License, "MIT" },
            { PluginMetadataType.Copyright, "Maksim Shimshon (c) 2026" },
        };
    public void Initialize() => throw new NotImplementedException();
    public void RegisterServices(IServiceCollection services) => throw new NotImplementedException();
    public void Unload() => throw new NotImplementedException();

}
