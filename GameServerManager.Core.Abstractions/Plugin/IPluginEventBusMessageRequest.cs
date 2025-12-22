namespace GameServerManager.Core.Abstractions.Plugin;

public interface IPluginEventBusMessageRequest
{
    string GetEventId();
    object? GetData();

}
