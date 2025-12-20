using GameServerManager.Core.Abstractions.Plugin;
using GameServerManager.Core.Abstractions.Plugin.Contracts;
using GameServerManager.Features.Lifecycle.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Features.Lifecycle;

public class Plugin : IPlugin<Plugin>, IPluginMetadata<Plugin>
{
    public string Name { get; init; } = "";
    public Version Version { get; init; } = new Version(1,0,0);
    public string? ProjectLink { get; init; } 
    public string? ProjectRepos { get; init; }

    public void Initialize() { }
    public void ConfigureEndpoints(IEndpointRouteBuilder routeBuilder) { }
    public void ConfigureWebBuilder(IApplicationBuilder applicationBuilder) { }
    public void ConfigureWebHost(IHostBuilder host) { }
    public void RegisterServices(IServiceCollection services)
    {
        services.AddLifecyclePresentation();
    }
    public void ThisIsHost(IHost host) { }
}
