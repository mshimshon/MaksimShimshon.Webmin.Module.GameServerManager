using GameServerManager.Skeleton.Bootstraper.Exceptions;
using McMaster.NETCore.Plugins;

namespace GameServerManager.Skeleton.Bootstraper;

public class PluginRegistry : IPluginRegistry
{
    public IDictionary<string, PluginLoader> Plugins { get; } = new Dictionary<string, PluginLoader>();

    public void Register(string key, PluginLoader pluginLoader)
    {
        key = key.ToLower();
        if (Plugins.ContainsKey(key)) 
            throw new DuplicatePluginException();
        Plugins[key] = pluginLoader;
    }
}
