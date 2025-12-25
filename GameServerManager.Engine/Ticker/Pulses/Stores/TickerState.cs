using StatePulse.Net;

namespace LunaticPanel.Engine.Ticker.Pulses.Stores;

public record TickerState : IStateFeatureSingleton
{
    public bool IsRunning { get; init; }
    public bool IsStarted { get; init; }
    public TimeOnly Interval { get; init; }
    public long Ticks { get; init; }

}
