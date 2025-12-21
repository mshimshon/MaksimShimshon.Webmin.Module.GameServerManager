using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Core.Providers.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameServerManager.Core;

public static class PluginServiceExt
{
    public static IServiceCollection AddEventBusHandler<TEventBusHandler>(
        this IServiceCollection services)
        where TEventBusHandler : class, IPluginEventBusHandler
    {
        var handlerType = typeof(TEventBusHandler);

        // Check for attribute
        var attr = handlerType.GetCustomAttribute<EventBusIdAttribute>();

        // Attribute overrides parameter
        var finalEventId = attr?.EventId;

        if (string.IsNullOrWhiteSpace(finalEventId))
            throw new InvalidOperationException($"EventBus handler '{handlerType.Name}' must specify an eventId either via parameter or EventBusIdAttribute.");

        var isSingleton = attr?.IsSingleton ?? false;

        if (isSingleton)
            services.AddSingleton<TEventBusHandler>();
        else
            services.AddScoped<TEventBusHandler>();

        // Register handler in the event bus registry
        PluginEventBusEngine.RegisterHandler(finalEventId, handlerType);

        return services;

    }
}
