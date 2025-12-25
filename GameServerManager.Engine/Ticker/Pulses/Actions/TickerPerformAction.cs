using StatePulse.Net;

namespace LunaticPanel.Engine.Ticker.Pulses.Actions;

public record TickerPerformAction : ISafeAction
{
    public long Tick { get; set; }
}
