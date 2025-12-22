using GameServerManager.Engine.Application.Messaging.Event;
using GameServerManager.Engine.Application.Messaging.Event.Exceptions;
using GameServerManager.Engine.Domain.Messaging.Event;
using GameServerManager.Plugin.Core.Messaging.EventSystem.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServerManager.Engine.Infrastructure.Messaging;

internal class EventBusRegistry : IEventBusRegistry
{
    private readonly Dictionary<string, List<EventTypeEntity>> _internalRegistryEventTypes = new();
    private readonly object _lock = new();

    public IReadOnlyList<string> GetAllAvailableIds()
    {
        lock (_lock)
        {
            return _internalRegistryEventTypes.Keys.ToList().AsReadOnly()!;
        }
    }

    public IReadOnlyList<EventTypeEntity> GetRegistryFor(string id)
    {
        id = id.ToLower();
        lock (_lock)
        { 
            return _internalRegistryEventTypes[id]?.ToList()?.AsReadOnly() ?? throw new NoEventBusIdEntryException(id);
        }
    }

    public void Register(string id, EventTypeEntity handlerEntity)
    {
        id = id.ToLower();

        lock (_lock)
        {
            if (!_internalRegistryEventTypes.TryGetValue(id, out var list))
            {
                list = new List<EventTypeEntity>();
                _internalRegistryEventTypes[id] = new List<EventTypeEntity>();
            }
            if (!list.Contains(handlerEntity))
                list.Add(handlerEntity);
        }
    }

    public void UnRegister(string id, EventTypeEntity handlerEntity)
    {
        id = id.ToLower();

        lock (_lock)
        {
            if (!_internalRegistryEventTypes.TryGetValue(id, out var list))
                return;
            list.Remove(handlerEntity);
        }
    }
}
