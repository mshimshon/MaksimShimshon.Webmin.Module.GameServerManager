using GameServerManager.Core.Abstractions.Dashboard.Menu.Contracts;
using StatePulse.Net;

namespace GameServerManager.Core.Abstractions.Dashboard.Menu.Pulses.Actions;

public record MenuOnAfterRenderAction : ISafeAction
{
    public bool IsFirstRender { get; set; }
}
