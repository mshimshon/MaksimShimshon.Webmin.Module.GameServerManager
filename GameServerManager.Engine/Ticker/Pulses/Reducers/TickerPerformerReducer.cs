using LunaticPanel.Engine.Ticker.Pulses.Actions;
using LunaticPanel.Engine.Ticker.Pulses.Stores;
using StatePulse.Net;
using System.Runtime.InteropServices;

namespace LunaticPanel.Engine.Ticker.Pulses.Reducers;

public class TickerPerformerReducer : IReducer<TickerState, TickerPerformAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerRunAction action)
    {
        var nextState = state with { IsStarted = true, IsRunning = true, Ticks = action.Tick };
        return await Task.FromResult(nextState);
    }
}
