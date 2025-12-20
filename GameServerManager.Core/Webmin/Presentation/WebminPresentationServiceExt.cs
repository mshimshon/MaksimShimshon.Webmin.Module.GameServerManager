using GameServerManager.Core.Shared.Webmin.Presentation.Components.ViewModels;
using GameServerManager.Core.Shared.Webmin.Presentation.Pages.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using StatePulse.Net;

namespace GameServerManager.Core.Shared.Webmin.Presentation;

public static class WebminPresentationServiceExt
{
    public static IServiceCollection AddWebminPresentation(this IServiceCollection services)
    {
        services.AddScoped<WebminModulePageViewModel>();
        services.AddScoped<WebminModuleFrameViewModel>();
        return services;
    }
}
