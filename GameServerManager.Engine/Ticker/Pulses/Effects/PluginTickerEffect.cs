using GameServerManager.Core.Abstractions.Plugin;
using LunaticPanel.Engine.Ticker.Pulses.Actions;
using LunaticPanel.Engine.Ticker.Pulses.Stores;
using StatePulse.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunaticPanel.Engine.Ticker.Pulses.Effects;

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
