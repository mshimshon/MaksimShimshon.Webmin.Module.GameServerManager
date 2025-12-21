namespace GameServerManager.Core.Abstractions.Event;

public interface IPluginEventBus
{
    IReadOnlyCollection<string> GetAllEventIds();
    IReadOnlyCollection<Type> GetAllHandlersByEventId(string eventId);
    Task PublishAsync(IPluginEventBusMessage evt);
}
