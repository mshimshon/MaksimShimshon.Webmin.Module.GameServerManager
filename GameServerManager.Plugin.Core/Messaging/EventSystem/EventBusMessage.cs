using GameServerManager.Plugin.Core.Messaging.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem;

public sealed class EventBusBusMessage : IEventBusMessage
{

    public BusMessageData? Data { get; }
    public string EventBaseId { get; }
    public string EventType { get; }
    public Guid Id { get; }
    public EventBusBusMessage(string eventBaseId, string eventType, object? data)
    {
        Id = Guid.NewGuid();

        if (data != default)
            Data = new BusMessageData(data);
        EventBaseId = eventBaseId;
        EventType = eventType;
    }
    
    public string GetId() => $"{EventBaseId}.{EventType}";

    public object? GetData() => Data?.GetData();
    public Guid GetMessageId() => Id;
}
