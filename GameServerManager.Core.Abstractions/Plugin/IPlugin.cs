using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Core.Abstractions.Plugin;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar", "S2326")]
public interface IPlugin<TEntry> 
    where TEntry : class
{
    void Initialize();
    void RegisterServices(IServiceCollection services);
    void ConfigureWebBuilder(IApplicationBuilder applicationBuilder);
    void ConfigureEndpoints(IEndpointRouteBuilder routeBuilder);
    void ConfigureWebHost(IHostBuilder host);
    void ThisIsHost(IHost host);
    void Unload();
}
