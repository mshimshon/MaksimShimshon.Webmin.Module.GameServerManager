using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Core.Abstractions.Event;

public abstract class EventMessage : EventMessageNoData
{
    protected object Data { get; }
    protected EventMessage(string eventType, object data) : base(eventType)
    {
        Data = data;
    }

    protected EventMessage(string baseEventId, string eventType, object data) : base(eventType, baseEventId)
    {
        Data = data;
    }
    public override object GetData() => Data!;
    public override string GetEventId() => $"{EventBaseId}.{EventType}";
}
