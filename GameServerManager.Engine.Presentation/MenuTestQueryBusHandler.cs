using GameServerManager.Plugin.Core.Messaging.EventSystem;
using GameServerManager.Plugin.Core.Messaging.QuerySystem;

namespace GameServerManager.Engine.Presentation;

[QueryBusId("Engine.QueryBus.Test")]
public class MenuTestQueryBusHandler : IQueryBusHandler
{
    public Task<QueryBusMessageResponse> HandleAsync(IQueryBusMessage qry)
    {
        return Task.FromResult(new QueryBusMessageResponse(new(true)));
    }
}
