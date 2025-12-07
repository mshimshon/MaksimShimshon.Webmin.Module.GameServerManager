using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;

public record LifecycleSystemState : IStateFeature
{
    public SystemInfoEntity? SystemInfo { get; init; }
}
