using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Commands;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Effects;

public class LifecycleServerStartEffect : IEffect<LifecycleServerStartAction>
{
    private readonly IStateAccessor<LifecycleServerState> _stateAccessor;
    private readonly IMedihater _medihater;

    public LifecycleServerStartEffect(IStateAccessor<LifecycleServerState> stateAccessor, IMedihater medihater)
    {
        _stateAccessor = stateAccessor;
        _medihater = medihater;
    }
    public async Task EffectAsync(LifecycleServerStartAction action, IDispatcher dispatcher)
    {
        Console.WriteLine("Server Launch has been dispatched.");
        var exec = new ExecStartServerCommand();
        var serverInfo = await _medihater.Send(exec);

        var dispatchPrep = dispatcher.Prepare<LifecycleServerStartDoneAction>();
        dispatchPrep.With(p => p.ServerInfo, serverInfo);
        if (serverInfo == default) {
            dispatchPrep.With(p => p.ErrorCode, "CONNERR");
            dispatchPrep.With(p => p.ErrorMessage, "Something was wrong with the connection, empty server info.");
        }
        await dispatchPrep.DispatchAsync();
    }   
}
