using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Events;

public enum LifecycleEvents
{
    ServerStartBegin,
    ServerStartFailed,
    ServerStartSuccess,
    ServerStartFinish,

    ServerStatusChanged
}
