using GameServerManager.Dashboard.Shared.Ticker.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Ticker.Pulses.Stores;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Dashboard;

public partial class App : ComponentBase
{
    [Inject] private IDispatcher Dispatcher { get; set; } = default!;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
                await Dispatcher.Prepare<TickerStartAction>().With(p=>p.TickInterval, new TimeOnly(0, 0, 1)).DispatchAsync();
        }
    }


}
