namespace GameServerManager.Engine.Application.Messaging.Event.Exceptions;

public class EventBusNotFoundException : Exception
{
    public string Id { get; }
    public EventBusNotFoundException(string id) : base($"({id}) is not a registered event.")
    {
        Id = id;
    }
}
