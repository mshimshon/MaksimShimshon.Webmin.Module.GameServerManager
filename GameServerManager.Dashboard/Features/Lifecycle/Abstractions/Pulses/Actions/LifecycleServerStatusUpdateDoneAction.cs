using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;

public class LifecycleServerStatusUpdateDoneAction : ISafeAction
{
    public ServerInfoEntity? ServerInfo { get; set; }
}
