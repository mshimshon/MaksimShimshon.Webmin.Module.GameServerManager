using GameServerManager.Plugin.Core.Messaging.Common;
using GameServerManager.Plugin.Core.Messaging.QuerySystem.Exceptions;

namespace GameServerManager.Plugin.Core.Messaging.QuerySystem;

public sealed record QueryBusMessageResponse
{
    public string Origin { get; init; } = default!;
    public BusMessageData? Data { get; init; }
    public QueryBusMessageException? Error { get; init; }

}
