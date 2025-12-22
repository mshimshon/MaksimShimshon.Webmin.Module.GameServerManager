namespace GameServerManager.Core.Abstractions.Plugin;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class PluginEventBusIdAttribute : Attribute
{
    public string EventId { get; }
    public bool IsSingleton { get; set; } = false;

    public PluginEventBusIdAttribute(string eventId)
    {
        EventId = eventId;
    }
}