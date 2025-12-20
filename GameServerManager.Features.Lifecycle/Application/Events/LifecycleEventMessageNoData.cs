using GameServerManager.Core.Abstractions.Event;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public class LifecycleEventMessageNoData : LifecycleEventMessageBase, IEventBusMessage
{
    protected LifecycleEvents EventType { get; }
    public LifecycleEventMessageNoData(LifecycleEvents eventType)
    {
        EventType = eventType;
    }
    public object? GetData() => default;
    public string GetEventId() => $"{EventBaseId}.{EventType}";
}
