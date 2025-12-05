using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;

public class LifecycleServerStopDoneAction : IAction
{
    public ServerInfoEntity? ServerInfo { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
