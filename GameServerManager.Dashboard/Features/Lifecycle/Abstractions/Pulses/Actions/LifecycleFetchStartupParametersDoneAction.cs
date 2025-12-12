using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;

public record LifecycleFetchStartupParametersDoneAction : IAction
{
    public Dictionary<string, string> StartupParameters { get; init; } = default!;
}
