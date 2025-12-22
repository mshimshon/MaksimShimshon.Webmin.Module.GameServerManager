using StatePulse.Net;

namespace GameServerManager.Engine.Ticker.Pulses.Actions;

public record TickerPerformAction : ISafeAction
{
    public long Tick { get; set; }
}
