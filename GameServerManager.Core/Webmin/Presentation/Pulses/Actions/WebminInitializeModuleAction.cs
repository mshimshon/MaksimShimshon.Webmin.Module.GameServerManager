using MudBlazor;
using StatePulse.Net;

namespace GameServerManager.Core.Shared.Webmin.Presentation.Pulses.Actions;

public record WebminInitializeModuleAction : IAction
{
    public string ModuleName { get; set; } = default!;
}
