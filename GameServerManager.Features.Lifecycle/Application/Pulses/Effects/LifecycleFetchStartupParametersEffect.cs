using GameServerManager.Core.Abstractions.Plugin;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Queries;
using MedihatR;
using StatePulse.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleFetchStartupParametersEffect : IEffect<LifecycleFetchStartupParametersAction>
{
    private readonly IMedihater _medihater;
    private readonly IPluginEventBus _eventBus;

    public LifecycleFetchStartupParametersEffect(IMedihater medihater, IPluginEventBus eventBus)
    {
        _medihater = medihater;
        _eventBus = eventBus;
    }
    public async Task EffectAsync(LifecycleFetchStartupParametersAction action, IDispatcher dispatcher)
    {

        var exec = new GetStartupParametersQuery();
        Dictionary<string, string>? data = default;
        try
        {
            data = await _medihater.Send(exec);
        }
        finally
        {
            var dispatchPrep = dispatcher.Prepare<LifecycleFetchStartupParametersDoneAction>();
            dispatchPrep.With(p => p.StartupParameters, data);
            await dispatchPrep.DispatchAsync();
        }
        


    }
}
