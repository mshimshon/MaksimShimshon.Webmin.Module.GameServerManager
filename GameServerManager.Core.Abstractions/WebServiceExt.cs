using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Core.Abstractions;

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
