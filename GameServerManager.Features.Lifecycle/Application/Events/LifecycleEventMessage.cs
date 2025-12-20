using GameServerManager.Core.Abstractions.Event;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public class LifecycleEventMessage<TData> : LifecycleEventMessageBase, IEventBusMessage
{
    protected TData Data { get; }
    protected LifecycleEvents EventType { get; }
    public LifecycleEventMessage(LifecycleEvents eventType, TData data)
    {
        EventType = eventType;
        Data = data;
    }
    public object GetData() => Data!;
    public string GetEventId() => $"{EventBaseId}.{EventType}";
}
