using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Shared.Providers.Abstraction;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers;

public class LifecycleService : ILifecycleServices
{
    private readonly IWebClient _webClient;

    public LifecycleService(IWebClient webClient)
    {
        _webClient = webClient;
    }
    public Task<ServerInfoEntity> ServerRestartAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ServerInfoEntity> ServerStartAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ServerInfoEntity> ServerStatusAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ServerInfoEntity> ServerStopAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
