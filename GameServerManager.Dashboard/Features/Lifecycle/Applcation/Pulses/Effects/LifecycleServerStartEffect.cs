using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Effects;

public class LifecycleServerStartEffect : IEffect<LifecycleServerStartAction>
{
    private readonly IStateAccessor<LifecycleServerState> _stateAccessor;

    public LifecycleServerStartEffect(IStateAccessor<LifecycleServerState> stateAccessor)
    {
        _stateAccessor = stateAccessor;
    }
    public async Task EffectAsync(LifecycleServerStartAction action, IDispatcher dispatcher)
    {
        Console.WriteLine("Server Launch has been dispatched.");
        await dispatcher.Prepare<LifecycleServerStartDoneAction>()
            .With(p => p.IsStarted, !_stateAccessor.State.IsRunning).DispatchAsync();
    }   
}
