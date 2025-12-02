using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;

public record LifecycleServerState : IStateFeature
{
    public bool IsRunning { get; init; }
    public string? LastRunErrorCode { get; init; }
    public string? LastRunErrorMessage { get; init; }
}
