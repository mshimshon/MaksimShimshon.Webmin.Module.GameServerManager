using LunaticPanel.Engine.Ticker.Pulses.Actions;
using LunaticPanel.Engine.Ticker.Pulses.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using StatePulse.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace LunaticPanel.Engine.Services;

public static class TickerExt
{
    private static TimeOnly TickInterval { get; set; } = new TimeOnly(0, 0, 1);
    private static Queue<long> AverageTiming { get; } = new();
    public static void StartTicker(this WebApplication webApplication, TimeOnly tickInterval)
    {
        TickInterval = tickInterval;
        _ = TickerLoop(webApplication.Services.CreateScope().ServiceProvider);
    }
    private static async Task TickerLoop(IServiceProvider serviceProvider)
    {

        var tickerStateAccess = serviceProvider.GetRequiredService<IStateAccessor<TickerState>>();
        // skip when running already
        if (!tickerStateAccess.State.IsStarted)
        {
            var sw = Stopwatch.StartNew();

            var statepulse = serviceProvider.GetRequiredService<IStatePulse>();
            var dispatcher = serviceProvider.GetRequiredService<IDispatcher>();
            try
            {
                var nextTickCount = tickerStateAccess.State.Ticks >= long.MaxValue ? 1 : tickerStateAccess.State.Ticks + 1;
                await dispatcher.Prepare<TickerPerformAction>().With(p => p.Tick, nextTickCount).Await().DispatchAsync();

                await dispatcher.Prepare<TickerPerformedAction>().DispatchAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();
            if (AverageTiming.Count > 10) 
                AverageTiming.Dequeue();
            AverageTiming.Enqueue(sw.ElapsedMilliseconds);
            long sum = AverageTiming.Sum(p => p);
            double avg = sum <= 0 ? 0 : sum / AverageTiming.Count;
            if (avg > 5000)
                Console.WriteLine($"WARN: The Ticker is extremely clogged {avg}ms, one or more plugin is causing frame drop.");
            else if (avg > 2000)
                Console.WriteLine($"WARN: The Ticker is clogged with timing avrage of {avg}ms, one or more plugin is causing frame drop.");
            else if (avg > 1000)
                Console.WriteLine($"WARN: The Ticker is slightly clogged with timing avrage of {avg}ms, one or more plugin is causing frame drop.");
        }

        await Task.Delay(TickInterval.ToTimeSpan());
        _ = TickerLoop(serviceProvider);
    }
}
