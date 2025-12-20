using GameServerManager.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Stores;

public record LifecycleSystemState : IStateFeature
{
    public SystemInfoEntity? SystemInfo { get; init; }
}
