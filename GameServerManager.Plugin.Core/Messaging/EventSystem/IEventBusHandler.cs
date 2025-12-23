namespace GameServerManager.Plugin.Core.Messaging.EventSystem;

public interface IEventBusHandler
{
    Task HandleAsync(IEventBusMessage evt);
}
