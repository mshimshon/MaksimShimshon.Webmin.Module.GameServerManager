using GameServerManager.Plugin.Core.Messaging.QuerySystem;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem;

public interface IEventBus
{
    IReadOnlyCollection<string> GetAllEventIds();
    IReadOnlyCollection<Type> GetAllHandlersByEventId(string eventId);
    Task PublishAsync(IEventBusMessage evt);
}
