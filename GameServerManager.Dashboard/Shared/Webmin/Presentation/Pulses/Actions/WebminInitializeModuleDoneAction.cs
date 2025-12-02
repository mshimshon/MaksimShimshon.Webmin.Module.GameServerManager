using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;

public record WebminInitializeModuleDoneAction : IAction
{
    public string ModuleName { get; init; } = default!;
    public string? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
}
