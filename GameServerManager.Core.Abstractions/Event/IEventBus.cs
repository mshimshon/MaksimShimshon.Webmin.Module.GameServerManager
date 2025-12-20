namespace GameServerManager.Core.Abstractions.Event;

public interface IEventBus
{
    Task PublishAsync(IEventBusMessage evt);
}
