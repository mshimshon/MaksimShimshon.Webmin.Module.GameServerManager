using GameServerManager.Core.Abstractions.Event;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameServerManager.Core.Providers.Infrastructure.Services;

internal class PluginEventBusEngine : IPluginEventBus
{
    private static readonly Dictionary<string, List<Type>> _internalRegistryEventTypes = new();
    private static readonly object _lock = new();

    public Task PublishAsync(IPluginEventBusMessage evt)
        => throw new NotImplementedException();

    public static void RegisterHandler(string eventId, Type handlerType)
    {
        eventId = eventId.ToLower();

        lock (_lock)
        {
            if (!_internalRegistryEventTypes.TryGetValue(eventId, out var list))
            {
                list = new List<Type>();
                _internalRegistryEventTypes[eventId] = list;
            }

            if (!list.Contains(handlerType))
                list.Add(handlerType);
        }
    }

    public IReadOnlyCollection<string> GetAllEventIds()
    {
        lock (_lock)
        {
            return _internalRegistryEventTypes.Keys.ToList().AsReadOnly();
        }
    }

    public IReadOnlyCollection<Type> GetAllHandlersByEventId(string eventId)
    {
        eventId = eventId.ToLower();

        lock (_lock)
        {
            if (_internalRegistryEventTypes.TryGetValue(eventId, out var list))
                return list.AsReadOnly();
            return Array.Empty<Type>();
        }
    }
}
