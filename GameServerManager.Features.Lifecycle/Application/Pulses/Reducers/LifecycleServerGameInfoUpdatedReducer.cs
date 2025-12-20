using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers;

public class LifecycleServerGameInfoUpdatedReducer : IReducer<LifecycleGameInfoState, LifecycleServerGameInfoUpdatedAction>
{
    private readonly IEventBus _eventBus;

    public LifecycleServerGameInfoUpdatedReducer(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public async Task<LifecycleGameInfoState> ReduceAsync(LifecycleGameInfoState state, LifecycleServerGameInfoUpdatedAction action)
    {
        var nstate = state with { GameInfo = action.GameInfo };
        await _eventBus.PublishAsync(new LifecycleEventMessage(LifecycleEvents.GameInfoUpdated, nstate));
        return nstate;
    } 
}
