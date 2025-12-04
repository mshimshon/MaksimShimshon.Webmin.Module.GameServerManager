using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using StatePulse.Net;
using System.ComponentModel.DataAnnotations;

namespace GameServerManager.Dashboard.Shared.Ticker.Pulses.Effects;

public class TickerStartEffect : IEffect<TickerStartAction>
{
    private IStateAccessor<TickerState> _stateAccessor;
    public TickerStartEffect(IStateAccessor<TickerState>  stateAccessor)
    {
        _stateAccessor = stateAccessor;
    }
    public async Task EffectAsync(TickerStartAction action, IDispatcher dispatcher)
    {

        if (_stateAccessor.State.IsStarted) return;
        //Console.WriteLine("Global Ticker Has Started");
        do
        {
            try
            {
                var nextTickCount = _stateAccessor.State.Ticks >= long.MaxValue ? 1 : _stateAccessor.State.Ticks + 1;
                //Console.WriteLine($"Global Ticker Performing Tick ({nextTickCount})");
                await dispatcher.Prepare<TickerRunAction>().With(p => p.Tick, nextTickCount).Await().DispatchAsync();
                await dispatcher.Prepare<TickerPerformerAction>().DispatchAsync();
                await dispatcher.Prepare<TickerRunDoneAction>().DispatchAsync();
                //Console.WriteLine($"Global Ticker Performed Tick ({nextTickCount}), Now Waiting");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            await Task.Delay(action.TickInterval.ToTimeSpan());
        } while (true);
    }

}
