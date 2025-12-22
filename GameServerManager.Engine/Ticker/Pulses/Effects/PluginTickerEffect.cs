using GameServerManager.Core.Abstractions.Plugin;
using GameServerManager.Engine.Ticker.Pulses.Actions;
using GameServerManager.Engine.Ticker.Pulses.Stores;
using StatePulse.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine.Ticker.Pulses.Effects;

internal class PluginTickerEffect : IEffect<TickerPerformAction>
{
    private readonly IPluginEventBus _pluginEventBus;
    private readonly IStateAccessor<TickerState> _tickerStateAccess;

    public PluginTickerEffect(IPluginEventBus pluginEventBus, IStateAccessor<TickerState> tickerStateAccess)
    {
        _pluginEventBus = pluginEventBus;
        _tickerStateAccess = tickerStateAccess;
    }
    public async Task EffectAsync(TickerPerformAction action, IDispatcher dispatcher)
    {
        var eventPublishing = new PluginEventBusMessageRequest($"{typeof(ServiceRegisterExt).Namespace!}.EventBus", EngineEvents.TickerPerform.ToString(), _tickerStateAccess.State);
        await _pluginEventBus.PublishAsync(eventPublishing);
    }
}
