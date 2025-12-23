using GameServerManager.Plugin.Core.Dashboard.Menu.DTOs;
using GameServerManager.Plugin.Core.Plugin.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Plugin.Core;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar", "S2326")]
public interface IPlugin<TEntry>
    where TEntry : class
{
    IReadOnlyDictionary<PluginMetadataType, string> GetMetadata();
    IReadOnlyCollection<MenuItemDto>? GetMenuItems();
    void Initialize();
    void RegisterServices(IServiceCollection services);
    void Unload();
}
