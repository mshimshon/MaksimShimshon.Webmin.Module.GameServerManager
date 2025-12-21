namespace GameServerManager.Core.Abstractions.Event;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class EventBusIdAttribute : Attribute
{
    public string EventId { get; }
    public bool IsSingleton { get; set; } = false;

    public EventBusIdAttribute(string eventId)
    {
        EventId = eventId;
    }
}