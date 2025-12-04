using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using StatePulse.Net;
using System.Runtime.InteropServices;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Reducers;

public class TickerRunReducer : IReducer<TickerState, TickerRunAction>
{
    public async Task<TickerState> ReduceAsync(TickerState state, TickerRunAction action)
    {
        var nextState = state with { IsStarted = true, IsRunning = true, Ticks = action.Tick };
        //Console.WriteLine($"TickerState has Reduced to ({nextState.ToString()})");
        return await Task.FromResult(nextState);
    }
}
