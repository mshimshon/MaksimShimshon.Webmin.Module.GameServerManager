using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameServerManager.Core.Abstractions.Plugin;

public abstract class PluginEventBusMessageRequestNoData : IPluginEventBusMessageRequest
{
    protected string EventBaseId { get; }
    protected string EventType { get; }
    protected PluginEventBusMessageRequestNoData(string baseEventId, string eventType) 
    {
        EventBaseId = baseEventId;
        EventType = eventType;
    }

    public virtual object? GetData() => default;
    public virtual string GetEventId() => $"{EventBaseId}.{EventType}";
}
