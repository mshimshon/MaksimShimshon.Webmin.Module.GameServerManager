using StatePulse.Net;

namespace GameServerManager.Core.Shared.Ticker.Pulses.Actions;

public record TickerStartAction : ISafeAction
{
    public TimeOnly TickInterval { get; set; } = new TimeOnly(0, 0, 1);
}
