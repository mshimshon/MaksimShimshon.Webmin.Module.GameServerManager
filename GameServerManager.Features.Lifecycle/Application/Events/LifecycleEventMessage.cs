using GameServerManager.Core.Abstractions.Event;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public class LifecycleEventMessage : Core.Abstractions.Event.EventMessage
{
    public LifecycleEventMessage(LifecycleEvents eventType, object data) : base(eventType.ToString(), data){}
    public LifecycleEventMessage(string baseEventIdTarget, LifecycleEvents eventType, object data) : base(baseEventIdTarget, eventType.ToString(), data){ }
}
