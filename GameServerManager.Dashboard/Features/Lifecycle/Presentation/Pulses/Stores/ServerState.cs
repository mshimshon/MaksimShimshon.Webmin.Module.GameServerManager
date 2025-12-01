using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pulses.Stores;

public class ServerState : IStateFeature
{
    public bool IsRunning { get; init; }
}
