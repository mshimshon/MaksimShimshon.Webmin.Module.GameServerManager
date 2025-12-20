using GameServerManager.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Actions;

public record LifecycleServerSystemInfoUpdatedAction : IAction
{
    public SystemInfoEntity SystemInfo { get; set; } = default!;
}
