using LunaticPanel.Engine.Ticker.Pulses.Actions;
using LunaticPanel.Engine.Ticker.Pulses.Stores;
using StatePulse.Net;

namespace LunaticPanel.Engine.Ticker.Pulses.Reducers;

public class TickerPerformedReducer : IReducerSingleton<TickerState, TickerPerformedAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerPerformedAction action)
        => await Task.FromResult(state with { IsRunning = false });
}
