using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Features.Lifecycle.Application.Pulses.Stores.Enums;
using StatePulse.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Reducers.Middlewares;

internal class ServerStatusChangedMiddleware : IReducerMiddleware
{
    private readonly IPluginEventBus _eventBus;

    public ServerStatusChangedMiddleware(IPluginEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public Task AfterReducing(object state, object action) => Task.CompletedTask;
    public async Task BeforeReducing(object state, object action)
    {
        bool isCorrectTargetAction = action is LifecycleServerStatusUpdateDoneAction;
        bool isCorrectTargetState = state is LifecycleServerState;
        if (!isCorrectTargetAction || !isCorrectTargetState) return;
        LifecycleServerState serverState = (LifecycleServerState)state;
        await _eventBus.PublishAsync(new LifecycleEventMessage(LifecycleEvents.ServerStatusChanged, serverState));
    }

}
