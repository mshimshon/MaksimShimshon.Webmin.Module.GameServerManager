using GameServerManager.Core.Abstractions;
using GameServerManager.Features.Lifecycle.Application;
using GameServerManager.Features.Lifecycle.Application.Services;
using GameServerManager.Features.Lifecycle.Infrastruture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Features.Lifecycle.Infrastruture;

public static class LifecycleInfrastructureServiceExt
{
    public static IServiceCollection AddLifecycleInfrastructure(this IServiceCollection services)
    {
        services.AddWebService<ILifecycleServices, LifecycleService>((sp,configure) =>
        {
            var baseUrl = new Uri("");
            configure.BaseAddress = new Uri(baseUrl, "scripts/lifecycle/");
        });
        services.AddLifecycleApplication();

        return services;
    }
}
