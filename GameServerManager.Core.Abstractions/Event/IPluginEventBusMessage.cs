namespace GameServerManager.Core.Abstractions.Event;

public interface IPluginEventBusMessage
{
    string GetEventId();
    object? GetData();

}
