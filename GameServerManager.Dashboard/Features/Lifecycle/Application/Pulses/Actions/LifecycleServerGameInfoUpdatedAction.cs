using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;

public record LifecycleServerGameInfoUpdatedAction : IAction
{
    public GameInfoEntity GameInfo { get; set; } = default!;
}
