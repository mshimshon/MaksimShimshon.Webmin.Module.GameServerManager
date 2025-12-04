using System.Net.Http;

namespace GameServerManager.Dashboard.Shared.Providers.Abstraction;

public interface IWebClient
{
    Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken = default);
    Task<string> GetStringAsync(string? requestUri, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}
