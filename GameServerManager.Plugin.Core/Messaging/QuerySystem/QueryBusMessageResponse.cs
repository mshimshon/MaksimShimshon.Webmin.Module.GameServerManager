using GameServerManager.Plugin.Core.Messaging.Common;

namespace GameServerManager.Plugin.Core.Messaging.QuerySystem;

public sealed record QueryBusMessageResponse
{
    public string Origin { get; init; } = default!;
    public BusMessageData? Data { get; init; }
    public Exception? Error { get; init; }

}
