using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;

namespace GameServerManager.Dashboard.Shared.Extensions;

public static class WebServiceExt
{
    public static IServiceCollection AddWebService<TFeatureServiceInterface, TFeatureServiceImplementation>(this IServiceCollection services, Action<IServiceProvider, TFeatureServiceImplementation> configure) 
        where TFeatureServiceInterface : class
        where TFeatureServiceImplementation : class, TFeatureServiceInterface
    {
        services.AddScoped<TFeatureServiceInterface, TFeatureServiceImplementation>(sp =>
        {
            var instance = ActivatorUtilities.CreateInstance<TFeatureServiceImplementation>(sp);
            configure(sp, instance);
            return instance;
        });
        return services;
    }
}
