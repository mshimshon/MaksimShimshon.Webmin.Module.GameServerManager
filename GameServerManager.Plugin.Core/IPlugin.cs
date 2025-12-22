using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Plugin.Core;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar", "S2326")]
public interface IPlugin<TEntry> 
    where TEntry : class
{
    void Initialize();
    /// <summary>
    /// Define the type of component that will be loaded inside the head tag such as script, css, metadata for the global
    /// </summary>
    /// <returns></returns>
    Type Head();
    /// <summary>
    /// Define the Component that will be inserted into the Body ie: Script loaded at the end.
    /// </summary>
    Type Body();
    void RegisterServices(IServiceCollection services);
    void ConfigureWebBuilder(IApplicationBuilder applicationBuilder);
    void ConfigureEndpoints(IEndpointRouteBuilder routeBuilder);
    void ConfigureWebHost(IHostBuilder host);
    void ThisIsHost(IHost host);
    void Unload();
}
