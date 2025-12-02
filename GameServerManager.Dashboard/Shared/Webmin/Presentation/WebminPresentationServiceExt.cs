using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Effects;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Reducers;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation;

public static class WebminPresentationServiceExt
{
    public static IServiceCollection AddWebminPresentation(this IServiceCollection services)
    {
        services.AddScoped<WebminModulePageViewModel>();
        services.AddScoped<WebminModuleFrameViewModel>();
        return services;
    }
}
