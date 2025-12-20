using GameServerManager.Core.Abstractions.Plugin;
using McMaster.NETCore.Plugins;

namespace GameServerManager.Skeleton.Bootstraper;

public interface IPluginRegistry
{
    public IDictionary<string, PluginLoader> Plugins { get; }
    void Register(string key, PluginLoader pluginLoader);

}
