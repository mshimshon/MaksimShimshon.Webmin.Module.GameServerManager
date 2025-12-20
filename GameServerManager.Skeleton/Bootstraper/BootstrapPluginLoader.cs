using DotNetCore.CAP;
using GameServerManager.Core.Abstractions.Plugin;
using McMaster.NETCore.Plugins;

namespace GameServerManager.Skeleton.Bootstraper;

public static class BootstrapPluginLoader
{
    public static IServiceCollection RegisterPlugins(this IServiceCollection services, string pluginFolder)
    {
        string[] pluginFolders = Directory.GetDirectories(pluginFolder);
        string[] potentialDlls = pluginFolders.SelectMany(p=> Directory.GetFiles(p, "*.dll", SearchOption.TopDirectoryOnly)).ToArray();
        foreach (var dll in potentialDlls)
        {
            var loader = PluginLoader.CreateFromAssemblyFile(dll, true, new Type[] { });

            var assembly = loader.LoadDefaultAssembly();
            var pluginTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract)
                .Select(t => new { Type = t, PluginInterface = t.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPlugin<>)) })
                .Where(x => x.PluginInterface != null);

            foreach (var plugin in pluginTypes)
            {
                var entryType = plugin.PluginInterface!.GetGenericArguments()[0];
                services.AddScoped(plugin.PluginInterface, plugin.Type);
                services.AddScoped(plugin.Type);
                Console.WriteLine($"Registered plugin {plugin.Type.Name} for entry {entryType.Name}");
            }
        }
        return services;
    }



}
