using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameServerManager.Core.Abstractions.Plugin;

public abstract class PluginEventBusMessageRequest : PluginEventBusMessageRequestNoData
{

    public PluginEventBusMessageData Data { get; }
    protected PluginEventBusMessageRequest(string baseEventId, string eventType, object data) : base(baseEventId, eventType)
    {
        Data = new PluginEventBusMessageData(data);
    }
    
    public override string GetEventId() => $"{EventBaseId}.{EventType}";

    public override object? GetData() => Data.GetData();

}
