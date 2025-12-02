using MudBlazor;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;

public record WebminModuleFrameState : IStateFeature
{
    public bool IsLoading { get; init; }
    public string? ModuleName { get; init; }
    public bool IsReady { get; init; }
    public string? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
}
