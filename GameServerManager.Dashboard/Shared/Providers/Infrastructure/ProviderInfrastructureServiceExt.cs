using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;
using GameServerManager.Dashboard.Shared.Providers.Abstraction;
using GameServerManager.Dashboard.Shared.Providers.Infrastructure.Services;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Providers.Presentation;

public static class ProviderInfrastructureServiceExt
{
    public static IServiceCollection AddProviderInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IWebClient, Webclient>();
        services.AddProviderApplication();
        services.AddHttpClient<IWebClient, Webclient>();
        return services;
    }
}
