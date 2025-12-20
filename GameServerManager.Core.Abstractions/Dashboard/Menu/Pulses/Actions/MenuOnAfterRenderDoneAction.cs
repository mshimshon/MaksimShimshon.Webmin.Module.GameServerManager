using StatePulse.Net;

namespace GameServerManager.Core.Abstractions.Dashboard.Menu.Pulses.Actions;

public record MenuOnAfterRenderDoneAction : ISafeAction
{
    public bool IsFirstRender { get; set; }
}
