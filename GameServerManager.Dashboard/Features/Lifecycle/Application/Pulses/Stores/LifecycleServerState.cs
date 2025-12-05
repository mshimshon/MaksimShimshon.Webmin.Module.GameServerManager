using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using Microsoft.Extensions.Options;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;

public record LifecycleServerState : IStateFeature
{
    public ServerInfoEntity? ServerInfo { get; init; }
    public DateTime ServerInfoLastUpdate { get; init; }
    public string? LastRunErrorCode { get; init; }
    public string? LastRunErrorMessage { get; init; }
    public int SkipNextUpdates { get; init; }
}
