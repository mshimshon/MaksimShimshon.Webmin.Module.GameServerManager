using GameServerManager.Core.Abstractions.Event;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public class LifecycleEventMessageNoData : Core.Abstractions.Event.EventMessageNoData
{
    public LifecycleEventMessageNoData(LifecycleEvents eventType) : base(eventType.ToString()) { }
    public LifecycleEventMessageNoData(string baseEventId, LifecycleEvents eventType) : base(baseEventId, eventType.ToString()) { }
}
