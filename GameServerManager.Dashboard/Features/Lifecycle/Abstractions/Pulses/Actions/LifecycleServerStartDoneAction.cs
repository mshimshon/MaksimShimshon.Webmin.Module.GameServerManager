using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;

public record LifecycleServerStartDoneAction : IAction
{
    public bool IsStarted { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
