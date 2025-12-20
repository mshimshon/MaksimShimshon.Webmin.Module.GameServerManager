using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Actions;

public record LifecycleUpdateStartupParameterAction : ISafeAction
{
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
}
