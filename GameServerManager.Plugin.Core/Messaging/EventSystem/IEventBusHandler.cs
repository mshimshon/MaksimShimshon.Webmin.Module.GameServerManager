using GameServerManager.Plugin.Core.Messaging.QuerySystem;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem;

public interface IEventBusHandler
{
    Task<QueryBusMessageResponse> HandleAsync(IEventBusMessage evt);
}
