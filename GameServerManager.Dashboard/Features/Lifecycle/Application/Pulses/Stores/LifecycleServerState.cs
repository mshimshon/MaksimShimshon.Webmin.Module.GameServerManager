using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores.Enums;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using Microsoft.Extensions.Options;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;

public record LifecycleServerState : IStateFeature
{
    public ServerInfoEntity? ServerInfo { get; init; }
    public ServerTransition Transition { get; init; } = ServerTransition.Idle;
    public int TransitionTicks { get; init; }

    public DateTime ServerInfoLastUpdate { get; init; }
    public string? LastRunErrorCode { get; init; }
    public string? LastRunErrorMessage { get; init; }
    public int SkipNextUpdates { get; init; }
    public int Delay { get; init; } = 8;
}
