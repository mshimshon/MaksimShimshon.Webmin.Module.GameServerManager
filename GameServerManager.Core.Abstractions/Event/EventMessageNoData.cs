using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameServerManager.Core.Abstractions.Event;

public abstract class EventMessageNoData : IPluginEventBusMessage
{
    protected string EventBaseId { get; }
    protected string EventType { get; }
    protected EventMessageNoData(string eventType)
    {
        EventBaseId = (Assembly.GetCallingAssembly()?.GetName()?.Name ?? typeof(EventMessageNoData).Namespace!) + ".EventBus";
        EventType = eventType;
    }
    protected EventMessageNoData(string baseEventId, string eventType) 
    {
        EventBaseId = baseEventId;
        EventType = eventType;
    }

    public virtual object? GetData() => default;
    public virtual string GetEventId() => $"{EventBaseId}.{EventType}";
}
