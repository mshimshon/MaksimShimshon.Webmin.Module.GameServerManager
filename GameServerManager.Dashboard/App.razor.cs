using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Dashboard;

public partial class App : ComponentBase
{
    [Inject] private IDispatcher Dispatcher { get; set; } = default!;
    [Inject] private IStateAccessor<TickerState> TickerStateAccessor { get; set; } = default!;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _= GlobalTickerStartAsync(new TickerStartAction() { TickInterval = new TimeOnly(0,0,1)}, Dispatcher);
        }
    }


    public async Task GlobalTickerStartAsync(TickerStartAction action, IDispatcher dispatcher)
    {

        TickerStateAccessor.OnStateChanged += (_, newState) => { Console.WriteLine($"TickerState has updated ({TickerStateAccessor.State.ToString()})"); };
        if (TickerStateAccessor.State.IsStarted) return;
        Console.WriteLine("Global Ticker Has Started");
        do
        {
            try
            {
                var nextTickCount = TickerStateAccessor.State.Ticks >= long.MaxValue ? 1 : TickerStateAccessor.State.Ticks + 1;
                Console.WriteLine($"Global Ticker Performing Tick ({nextTickCount})");
                await dispatcher.Prepare<TickerRunAction>().With(p => p.Tick, nextTickCount).Await().DispatchAsync();
                //await dispatcher.Prepare<TickerPerformerAction>().DispatchAsync();
                //await dispatcher.Prepare<TickerRunDoneAction>().DispatchAsync();
                Console.WriteLine($"Global Ticker Performed Tick ({nextTickCount}), Now Waiting");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            await Task.Delay(action.TickInterval.ToTimeSpan());
        } while (true);
    }
}
