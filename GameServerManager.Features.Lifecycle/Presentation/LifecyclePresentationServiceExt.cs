using GameServerManager.Features.Lifecycle.Infrastruture;
using GameServerManager.Features.Lifecycle.Presentation.Components.ViewModels;
using GameServerManager.Features.Lifecycle.Presentation.Pages.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Presentation;

public static class LifecyclePresentationServiceExt
{
    public static IServiceCollection AddLifecyclePresentation(this IServiceCollection services)
    {
        services.AddScoped<LifecyclePageViewModel>();
        services.AddScoped<LifecycleSystemResourcesStatusViewModel>();
        services.AddScoped<LifecycleStartupParameterViewModel>();
        services.AddTransient<LifecycleStartupParameterFieldViewModel>();
        services.AddLifecycleInfrastructure();
        return services;
    }
}
