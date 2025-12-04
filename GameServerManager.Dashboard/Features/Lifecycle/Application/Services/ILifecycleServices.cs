using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;

public interface ILifecycleServices
{
    Task<ServerInfoEntity> ServerStartAsync(CancellationToken cancellationToken = default);
    Task<ServerInfoEntity> ServerStopAsync(CancellationToken cancellationToken = default);
    Task<ServerInfoEntity> ServerRestartAsync(CancellationToken cancellationToken = default);
    Task<ServerInfoEntity> ServerStatusAsync(CancellationToken cancellationToken = default);
}
