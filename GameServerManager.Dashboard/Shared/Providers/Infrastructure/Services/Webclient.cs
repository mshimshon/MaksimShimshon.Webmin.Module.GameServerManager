using GameServerManager.Dashboard.Shared.Providers.Abstraction;

namespace GameServerManager.Dashboard.Shared.Providers.Infrastructure.Services;

public class Webclient : IWebClient
{
    HttpClient _httpClient;
    public Webclient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken = default)
        => _httpClient.DeleteAsync(requestUri, cancellationToken);

    public Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken = default)
        => _httpClient.GetAsync(requestUri, cancellationToken);

    public Task<string> GetStringAsync(string? requestUri, CancellationToken cancellationToken = default)
        => _httpClient.GetStringAsync(requestUri!, cancellationToken);

    public Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default)
        => _httpClient.PatchAsync(requestUri, content, cancellationToken);

    public Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default)
        => _httpClient.PostAsync(requestUri, content, cancellationToken);

    public Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default)
        => _httpClient.PutAsync(requestUri, content, cancellationToken);

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        => _httpClient.SendAsync(request, cancellationToken);
}
