using GameServerManager.Engine.Application.Messaging.Event;
using GameServerManager.Engine.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine.Application;

public static class RegisterServicesExt
{
    public static IServiceCollection AddEngineInfrastructure(this IServiceCollection services)
    {
        services.AddEngineApplication();
        services.AddSingleton<IEventBusRegistry, EventBusRegistry>();
        return services;
    }
}
