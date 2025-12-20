using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Actions;

public record LifecycleFetchStartupParametersDoneAction : IAction
{
    public Dictionary<string, string> StartupParameters { get; init; } = default!;
}
