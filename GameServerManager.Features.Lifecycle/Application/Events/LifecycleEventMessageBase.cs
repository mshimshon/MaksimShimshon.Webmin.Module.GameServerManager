using GameServerManager.Core.Abstractions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public abstract class LifecycleEventMessageBase
{
    protected string EventBaseId { get; }
    protected LifecycleEventMessageBase()
    {
        EventBaseId = typeof(LifecycleEventMessageBase).Namespace!;
    }
}
