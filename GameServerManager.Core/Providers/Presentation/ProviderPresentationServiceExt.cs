using GameServerManager.Core.Shared.Providers.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Core.Shared.Providers.Presentation;

public static class ProviderPresentationServiceExt
{
    public static IServiceCollection AddProviderPresentation(this IServiceCollection services)
    {
        services.AddProviderInfrastructure();
        return services;
    }
}
