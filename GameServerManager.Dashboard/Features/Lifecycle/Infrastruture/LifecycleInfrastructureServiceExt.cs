using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture;

public static class LifecycleInfrastructureServiceExt
{
    public static IServiceCollection AddLifecycleInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ILifecycleServices, LifecycleService>();


        return services;
    }
}
