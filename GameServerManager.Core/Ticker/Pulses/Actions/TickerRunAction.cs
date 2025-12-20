using StatePulse.Net;

namespace GameServerManager.Core.Shared.Ticker.Pulses.Actions;

public record TickerRunAction : ISafeAction
{
    public long Tick { get; set; }
}
