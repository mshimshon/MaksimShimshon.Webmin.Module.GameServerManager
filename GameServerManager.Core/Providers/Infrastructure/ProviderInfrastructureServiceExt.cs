using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Core.Providers.Infrastructure.Services;
using GameServerManager.Core.Shared.Providers.Abstraction;
using GameServerManager.Core.Shared.Providers.Application;
using GameServerManager.Core.Shared.Providers.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Core.Shared.Providers.Infrastructure;

public static class ProviderInfrastructureServiceExt
{
    public static IServiceCollection AddProviderInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IWebClient, Webclient>();
        services.AddHttpClient<IWebClient, Webclient>();
        services.AddProviderApplication();
        services.AddSingleton<IPluginEventBus, PluginEventBusEngine>();
        return services;
    }
}
