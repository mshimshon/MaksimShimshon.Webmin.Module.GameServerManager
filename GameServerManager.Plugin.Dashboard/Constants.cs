using System.Reflection;

namespace GameServerManager.Plugin.Dashboard;

public static class Constants
{
    public static string PluginIdKey { get; } = Assembly.GetExecutingAssembly()!.GetCustomAttribute<AssemblyMetadataAttribute>()?.Value!;
}
