using GameServerManager.Engine.Infrastructure;
using GameServerManager.Engine.Infrastructure.Circuit;
using GameServerManager.Engine.Presentation.Services;
using GameServerManager.Engine.Presentation.Services.Messaging.EngineBus;
using GameServerManager.Plugin.Core.Messaging.EngineBus;

namespace GameServerManager.Engine.Presentation;

public static class RegisterServicesExt
{
    public static IServiceCollection AddEnginePresentation(this IServiceCollection services)
    {
        services.AddEngineInfrastructure();
        services.AddScoped<CircuitRegistry>();
        services.AddScoped<ICircuitControl, CircuitRegistry>();
        services.AddSingleton<EngineBusRegistry>();
        services.AddScoped<IEngineBus, EngineBusService>();
        return services;
    }
}
