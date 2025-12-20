namespace GameServerManager.Core.Abstractions.Event;

public interface IEventBusMessage
{
    string GetEventId();
    object? GetData();
}
