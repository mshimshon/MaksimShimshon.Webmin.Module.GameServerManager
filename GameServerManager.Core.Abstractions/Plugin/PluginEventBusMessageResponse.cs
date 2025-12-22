namespace GameServerManager.Core.Abstractions.Plugin;

public record PluginEventBusMessageResponse
{
    public string Origin { get; init; } = default!;
    public PluginEventBusMessageData? Data { get; init; }
    public Exception? Error { get; init; }
}
