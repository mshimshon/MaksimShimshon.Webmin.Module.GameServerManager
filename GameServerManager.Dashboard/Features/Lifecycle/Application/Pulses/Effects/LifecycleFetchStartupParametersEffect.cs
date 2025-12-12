using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Queries;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Queries;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleFetchStartupParametersEffect : IEffect<LifecycleFetchStartupParametersAction>
{
    private readonly IMedihater _medihater;

    public LifecycleFetchStartupParametersEffect(IMedihater medihater)
    {
        _medihater = medihater;
    }
    public async Task EffectAsync(LifecycleFetchStartupParametersAction action, IDispatcher dispatcher)
    {

        var exec = new GetStartupParametersQuery();
        var data = await _medihater.Send(exec);


        var dispatchPrep = dispatcher.Prepare<LifecycleFetchStartupParametersDoneAction>();
        dispatchPrep.With(p => p.StartupParameters, data);
        await dispatchPrep.DispatchAsync();
    }
}
