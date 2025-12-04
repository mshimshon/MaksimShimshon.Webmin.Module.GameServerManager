using GameServerManager.Dashboard.Shared.Providers.Abstraction;

namespace GameServerManager.Dashboard.Shared.Providers.Infrastructure.Services;

public class Webclient : IWebClient
{
    HttpClient _httpClient;
    public Webclient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<string> GetStringAsync(string? requestUri, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
