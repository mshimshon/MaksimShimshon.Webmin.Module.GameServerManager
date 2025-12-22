using GameServerManager.Plugin.Core.Messaging.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem;

public sealed class QueryBusMessage : IBusMessage
{

    public BusMessageData? Data { get; }
    public string EventBaseId { get; }
    public string EventType { get; }
    public Guid Id { get;  }
    public QueryBusMessage(string queryBaseId, string queryType, object? data)
    {
        Id = Guid.NewGuid();
        if (data != default)
            Data = new BusMessageData(data);
        EventBaseId = queryBaseId;
        EventType = queryType;
    }

    public string GetId() => $"{EventBaseId}.{EventType}";

    public object? GetData() => Data?.GetData();
    public Guid GetMessageId() => Id;
}
