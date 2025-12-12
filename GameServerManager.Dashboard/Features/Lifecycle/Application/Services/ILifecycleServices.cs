using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;

public interface ILifecycleServices
{
    Task ServerStartAsync(CancellationToken cancellationToken = default);
    Task ServerStopAsync(CancellationToken cancellationToken = default);
    Task ServerRestartAsync(CancellationToken cancellationToken = default);
    Task<ServerInfoEntity> ServerStatusAsync(CancellationToken cancellationToken = default);
    Task<Dictionary<string, string>> GetServerStartupParametersAsync(CancellationToken cancellationToken = default);
    Task UpdateStartupParameterAsync(string key, string value, CancellationToken cancellationToken = default);
}
