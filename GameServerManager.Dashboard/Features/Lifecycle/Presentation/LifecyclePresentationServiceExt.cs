using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Effects;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Reducers;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation;

public static class LifecyclePresentationServiceExt
{
    public static IServiceCollection AddLifecyclePresentation(this IServiceCollection services)
    {
        services.AddScoped<LifecyclePageViewModel>();
        services.AddLifecycleInfrastructure();
        return services;
    }
}
