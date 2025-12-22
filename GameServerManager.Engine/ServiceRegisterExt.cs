using GameServerManager.Core;
using GameServerManager.Engine.Services.CircuitControl;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine;

public static class ServiceRegisterExt
{
    public static IServiceCollection AddEngineServices(this IServiceCollection services)
    {
     

        services.AddScoped<CircuitRegistry>();
        services.AddScoped<CircuitHandler, CircuitRegistry>();
        return services;
    }
}
