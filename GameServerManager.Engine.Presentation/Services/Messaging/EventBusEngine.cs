
using GameServerManager.Engine.Application.Messaging.Event;
using GameServerManager.Engine.Domain.Messaging.Event;
using GameServerManager.Engine.Presentation.Services.CircuitControl;
using GameServerManager.Plugin.Core.Messaging.EventSystem;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GameServerManager.Engine.Presentation.Services.Messaging;

internal class EventBusEngine : IEventBus
{

    private readonly IServiceProvider _serviceProvider;
    private readonly IEventBusRegistry _eventBusRegistry;

    public EventBusEngine(IServiceProvider serviceProvider, IEventBusRegistry eventBusRegistry)
    {
        _serviceProvider = serviceProvider;
        _eventBusRegistry = eventBusRegistry;
    }

    private static Task ExecuteHandler(IEventBusMessage evt, IServiceProvider serviceProvider, Type handlerType)
    {
        var handler = serviceProvider.GetRequiredService(handlerType) as IEventBusHandler;
        return handler!.HandleAsync(evt);
    }

    public Task PublishAsync(IEventBusMessage evt)
    {
        string id = evt.GetId();
        var registry = _eventBusRegistry;
        var handlers = registry.GetRegistryFor(id);
        List<Task> handlerTasks = new();
        bool hasCrossCircuitEvents = handlers.Any(p => p.IsCrossCircuitType);
        foreach (var item in handlers.Where(p => !p.IsCrossCircuitType))
            handlerTasks.Add(ExecuteHandler(evt, _serviceProvider, item.HandlerType));

        if (hasCrossCircuitEvents)
            foreach (var circuit in CircuitRegistry.GetActiveCircuits())
                foreach (var handlerType in handlers.Where(p => p.IsCrossCircuitType))
                    handlerTasks.Add(ExecuteHandler(evt, circuit.ServiceProvider!, handlerType.HandlerType));

        return Task.WhenAll(handlerTasks);
    }


    public IReadOnlyCollection<string> GetAllEventIds() => _eventBusRegistry.GetAllAvailableIds();

    public IReadOnlyCollection<Type> GetAllHandlersByEventId(string eventId) =>  _eventBusRegistry.GetRegistryFor(eventId).Select(p=>p.HandlerType).ToList().AsReadOnly();
}
