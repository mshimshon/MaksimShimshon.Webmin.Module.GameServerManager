using GameServerManager.Engine.Infrastructure;
using GameServerManager.Engine.Infrastructure.Circuit;
using GameServerManager.Engine.Presentation.Services;
using GameServerManager.Plugin.Core.Messaging.Engine.Hooks;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace GameServerManager.Engine.Presentation;

public static class RegisterServicesExt
{
    public static IServiceCollection AddEnginePresentation(this IServiceCollection services)
    {
        services.AddEngineInfrastructure();
        services.AddSingleton<CircuitRegistry>();
        services.AddSingleton<CircuitHandler, CircuitRegistry>();
        services.AddSingleton<ICircuitControl, CircuitRegistry>();
        services.AddSingleton<EngineBusRegistry>();
        services.AddScoped<IEngineBus, EngineBusService>();
        return services;
    }
}
