using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;

public record TickerState : IStateFeature
{
    public bool IsRunning { get; init; }
    public bool IsStarted { get; init; }
    public TimeOnly Interval { get; init; }
    public long Ticks { get; init; }

    public override string ToString() => $"IsRunning: {IsRunning}, IsStarted: {IsStarted}, Interval: {Interval}, Ticks: {Ticks}.";
}
