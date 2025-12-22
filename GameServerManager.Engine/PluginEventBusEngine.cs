using GameServerManager.Core.Abstractions.Plugin;
using GameServerManager.Core.Abstractions.Plugin.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameServerManager.Core.Providers.Infrastructure.Services;

internal class PluginEventBusEngine : IPluginEventBus
{
    private static readonly Dictionary<string, List<Type>> _internalRegistryEventTypes = new();
    private static readonly object _lock = new();
    private readonly IServiceProvider _serviceProvider;

    public PluginEventBusEngine(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task<IReadOnlyCollection<PluginEventBusMessageResponse>> PublishAsync(IPluginEventBusMessageRequest evt)
    {
        string id = evt.GetEventId();
        IReadOnlyCollection<Type> handlerTypes;
        lock (_lock)
        {
            if (!_internalRegistryEventTypes.TryGetValue(id, out var list))
                throw new NoPluginEventRegisteredWithIdException(evt);

            handlerTypes = list.ToList().AsReadOnly();
        }

        var scopedProvider = _serviceProvider;
        var handlers = handlerTypes
            .Select(t => (t, (IPluginEventBusHandler)scopedProvider.GetRequiredService(t)))
            .ToList();

        var tasks = handlers.Select(async ((Type t, IPluginEventBusHandler handler) data) => { 
            try
            {
                PluginEventBusMessageResponse result = await data.handler.HandleAsync(evt);
                return result with
                {
                    Origin = data.t.FullName!
                };
            }
            catch (Exception ex)
            {
                // THIS is where the exception is captured
                return new PluginEventBusMessageResponse() {
                    Origin = data.t.FullName!,
                    Error = ex
                };
            }
        }).ToList();

        var result = await Task.WhenAll(tasks);

        return result.ToList().AsReadOnly()!;
    }


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
