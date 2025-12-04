using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;
using GameServerManager.Dashboard.Shared.Exceptions;
using GameServerManager.Dashboard.Shared.Providers.Abstraction;
using GameServerManager.Dashboard.Shared.Webmin.Infrastruture.Exceptions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;

public class LifecycleService : ILifecycleServices
{
    private readonly IWebClient _webClient;
    private readonly IWebAssemblyHostEnvironment _webAssemblyHostEnvironment;
    private readonly ICoreMap _coreMap;

    public Uri BaseAddress { get; set; } = default!;
    public LifecycleService(IWebClient webClient, IWebAssemblyHostEnvironment webAssemblyHostEnvironment, ICoreMap coreMap)
    {
        _webClient = webClient;
        _webAssemblyHostEnvironment = webAssemblyHostEnvironment;
        _coreMap = coreMap;
    }
    public Task<ServerInfoEntity> ServerRestartAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ServerInfoEntity> ServerStartAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public async Task<ServerInfoEntity> ServerStatusAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = new Uri(BaseAddress, "server_status.cgi");
        Console.WriteLine(endpoint.ToString());
        var response = await _webClient.GetAsync(endpoint.ToString());
        if (response.IsSuccessStatusCode)
        {
            var serverInfoResponse = await response.Content.ReadFromJsonAsync<StatusResponse>();
            if (serverInfoResponse == default)
                throw new WebServiceException("Could't read server response.");
            var serverInfo = _coreMap.Map(serverInfoResponse).To<ServerInfoEntity>();
            return serverInfo;
        }
        else
            if (response.StatusCode == System.Net.HttpStatusCode.Redirect)
                throw new WebminLoginExpiredException("Could't read server response.");
        else if (response.StatusCode != System.Net.HttpStatusCode.BadRequest)
            throw new WebServiceException("Unknown Error");
        throw new WebServiceException("Bad Request");

    }
    public Task<ServerInfoEntity> ServerStopAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
