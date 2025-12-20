using GameServerManager.Core.Abstractions.Ticker.Pulses.Stores;
using GameServerManager.Core.Shared.Ticker.Pulses.Actions;
using StatePulse.Net;

namespace GameServerManager.Core.Shared.Ticker.Pulses.Reducers;

public class TickerRunDoneReducer : IReducer<TickerState, TickerRunDoneAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerRunDoneAction action)
        => await Task.FromResult(state with { IsRunning = false });
}
