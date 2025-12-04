using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;

namespace GameServerManager.Dashboard.Shared.Providers.Presentation;

public static class ProviderPresentationServiceExt
{
    public static IServiceCollection AddProviderPresentation(this IServiceCollection services)
    {
        services.AddProviderInfrastructure();
        return services;
    }
}
