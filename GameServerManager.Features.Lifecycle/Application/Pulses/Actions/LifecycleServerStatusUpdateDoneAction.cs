using GameServerManager.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Actions;

public class LifecycleServerStatusUpdateDoneAction : ISafeAction
{
    public ServerInfoEntity? ServerInfo { get; set; }
}
