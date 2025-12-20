using StatePulse.Net;

namespace GameServerManager.Core.Abstractions.Dashboard.MainLayout.Pulses.Actions;

public record MainLayoutOnAfterRenderAction : ISafeAction
{
    public bool IsFirstRender { get; set; }
}
