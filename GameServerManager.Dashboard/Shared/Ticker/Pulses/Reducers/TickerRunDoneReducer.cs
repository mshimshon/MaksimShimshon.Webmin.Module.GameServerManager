using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Reducers;

public class TickerRunDoneReducer : IReducer<TickerState, TickerRunAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerRunAction action)
        => await Task.FromResult(state with { IsRunning = false });
}
