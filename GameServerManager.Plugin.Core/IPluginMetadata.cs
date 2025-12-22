using GameServerManager.Core.Abstractions.Plugin.Contracts;

namespace GameServerManager.Plugin.Core;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar", "S2326")]
public interface IPluginMetadata<TEntry>
    where TEntry : class
{

    string Name { get; init; }
    Version Version { get; init; }
    string? ProjectLink { get; init; }
    string? ProjectRepos { get; init; }
}
