using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;
using GameServerManager.Dashboard.Shared.Exceptions;
using GameServerManager.Dashboard.Shared.Providers.Abstraction;
using GameServerManager.Dashboard.Shared.Webmin.Infrastruture.Exceptions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StatePulse.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;

public class LifecycleService : ILifecycleServices
{
    private const string _read_Server_Response_Error_Msg = "Could't read server response.";
    private const string _server_Bad_Request_Error_Msg = "Bad Request";
    private const string _server_Unknown_Error_Msg = "Unknown Error";
    private readonly IWebClient _webClient;
    private readonly ICoreMap _coreMap;

    public Uri BaseAddress { get; set; } = default!;
    public LifecycleService(IWebClient webClient, IWebAssemblyHostEnvironment webAssemblyHostEnvironment, ICoreMap coreMap)
    {
        _webClient = webClient;
        _coreMap = coreMap;
    }
    public Task ServerRestartAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public async Task ServerStartAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = new Uri(BaseAddress, "server_start.cgi");
        Console.WriteLine(endpoint.ToString());
        var response = await _webClient.GetAsync(endpoint.ToString());
        if (response.IsSuccessStatusCode)
            return;
        else if (response.StatusCode == System.Net.HttpStatusCode.Redirect)
            throw new WebminLoginExpiredException(_read_Server_Response_Error_Msg);
        else if (response.StatusCode != System.Net.HttpStatusCode.BadRequest)
            throw new WebServiceException(_server_Unknown_Error_Msg);
        throw new WebServiceException(_server_Bad_Request_Error_Msg);
    }
    public async Task<ServerInfoEntity> ServerStatusAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = new Uri(BaseAddress, "server_status.cgi");
        Console.WriteLine(endpoint.ToString());
        var response = await _webClient.GetAsync(endpoint.ToString());
        if (response.IsSuccessStatusCode)
        {
            try
            {
                var serverInfoResponse = await response.Content.ReadFromJsonAsync<StatusResponse>();
                Console.WriteLine($"{nameof(ServerStatusAsync)}: {serverInfoResponse}");
                if (serverInfoResponse == default)
                    throw new WebServiceException(_read_Server_Response_Error_Msg);
                var serverInfo = _coreMap.Map(serverInfoResponse).To<ServerInfoEntity>();
                return serverInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(ServerStatusAsync)}: {ex.Message}");
                throw new WebServiceException(_server_Bad_Request_Error_Msg);
            }

        }
        else
            if (response.StatusCode == System.Net.HttpStatusCode.Redirect)
                throw new WebminLoginExpiredException(_read_Server_Response_Error_Msg);
        else if (response.StatusCode != System.Net.HttpStatusCode.BadRequest)
            throw new WebServiceException(_server_Unknown_Error_Msg);
        throw new WebServiceException(_server_Bad_Request_Error_Msg);

    }
    public async Task ServerStopAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = new Uri(BaseAddress, "server_stop.cgi");
        Console.WriteLine(endpoint.ToString());
        var response = await _webClient.GetAsync(endpoint.ToString());
        if (response.IsSuccessStatusCode)
            return;
        else if (response.StatusCode == System.Net.HttpStatusCode.Redirect)
            throw new WebminLoginExpiredException(_read_Server_Response_Error_Msg);
        else if (response.StatusCode != System.Net.HttpStatusCode.BadRequest)
            throw new WebServiceException(_server_Unknown_Error_Msg);
        throw new WebServiceException(_server_Bad_Request_Error_Msg);
    }
}
