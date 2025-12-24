using GameServerManager.Engine.Domain.Plugin.ValueObjects;

namespace GameServerManager.Engine.Domain.Plugin.Entites;

public sealed record PluginEntity
{
    public string Id { get; }
    public PluginLifecycle Lifecycle { get; }

    public PluginEntity(string id, PluginLifecycle lifecycle)
    {
        Id = id;
        Lifecycle = lifecycle;
    }


}
