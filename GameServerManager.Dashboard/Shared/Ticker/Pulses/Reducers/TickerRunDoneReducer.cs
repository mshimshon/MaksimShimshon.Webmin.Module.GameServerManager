using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Reducers;

public class TickerRunDoneReducer : IReducer<TickerState, TickerRunDoneAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerRunDoneAction action)
        => await Task.FromResult(state with { IsRunning = false });
}
