using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;

public record TickerRunAction : ISafeAction
{
    public long Tick { get; set; }
}
