using MudBlazor;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;

public record WebminInitializeModuleAction : IAction
{
    public string ModuleName { get; set; } = default!;
}
