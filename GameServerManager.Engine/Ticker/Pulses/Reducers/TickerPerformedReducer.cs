using GameServerManager.Engine.Ticker.Pulses.Actions;
using GameServerManager.Engine.Ticker.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Engine.Ticker.Pulses.Reducers;

public class TickerPerformedReducer : IReducerSingleton<TickerState, TickerPerformedAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerPerformedAction action)
        => await Task.FromResult(state with { IsRunning = false });
}
