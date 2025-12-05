using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;
using GameServerManager.Dashboard.Shared.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture;

public static class LifecycleInfrastructureServiceExt
{
    public static IServiceCollection AddLifecycleInfrastructure(this IServiceCollection services)
    {
        services.AddWebService<ILifecycleServices, LifecycleService>((sp,configure) =>
        {
            var host = sp.GetRequiredService<IWebAssemblyHostEnvironment>();
            var baseUrl = new Uri(host.BaseAddress);
            configure.BaseAddress = new Uri(baseUrl, "scripts/lifecycle/");
        });


        return services;
    }
}
