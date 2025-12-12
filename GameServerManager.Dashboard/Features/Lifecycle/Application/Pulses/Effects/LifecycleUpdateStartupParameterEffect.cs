using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Commands;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Queries;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Effects;

public class LifecycleUpdateStartupParameterEffect : IEffect<LifecycleUpdateStartupParameterAction>
{
    private readonly IMedihater _medihater;

    public LifecycleUpdateStartupParameterEffect(IMedihater medihater)
    {
        _medihater = medihater;
    }
    public async Task EffectAsync(LifecycleUpdateStartupParameterAction action, IDispatcher dispatcher)
    {
        var exec = new ExecUpdateStartupParameterCommand() {
            Key = action.Key,
            Value = action.Value
        };
        await _medihater.Send(exec);

    }
}
