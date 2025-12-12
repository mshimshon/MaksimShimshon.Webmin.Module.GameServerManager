using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;

public record LifecycleServerSystemInfoUpdatedAction : IAction
{
    public SystemInfoEntity SystemInfo { get; set; } = default!;
}
