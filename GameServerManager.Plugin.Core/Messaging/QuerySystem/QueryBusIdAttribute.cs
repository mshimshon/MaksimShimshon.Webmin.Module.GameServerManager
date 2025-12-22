namespace GameServerManager.Plugin.Core.Messaging.EventSystem;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class QueryBusIdAttribute : Attribute
{
    public string QueryId { get; }
    public QueryBusIdAttribute(string eventId)
    {
        QueryId = eventId;
    }
}