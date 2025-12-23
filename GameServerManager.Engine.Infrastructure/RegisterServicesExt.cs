using GameServerManager.Engine.Application;
using GameServerManager.Engine.Application.Messaging.Event;
using GameServerManager.Engine.Application.Messaging.Query;
using GameServerManager.Engine.Infrastructure.Messaging.Event;
using GameServerManager.Engine.Infrastructure.Messaging.Query;
using GameServerManager.Engine.Presentation.Services.Messaging;
using GameServerManager.Plugin.Core.Messaging.EventSystem;
using GameServerManager.Plugin.Core.Messaging.QuerySystem;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Engine.Infrastructure;

public static class RegisterServicesExt
{
    public static IServiceCollection AddEngineInfrastructure(this IServiceCollection services)
    {
        services.AddEngineApplication();
        services.AddScoped<IEventBus, EventBus>();
        services.AddSingleton<IEventBusRegistry, EventBusRegistry>();

        services.AddScoped<IQueryBus, QueryBus>();
        services.AddSingleton<IQueryBusRegistry, QueryBusRegistry>();

        return services;
    }
}
