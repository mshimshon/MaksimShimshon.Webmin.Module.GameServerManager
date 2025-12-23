using GameServerManager.Plugin.Core.Messaging.Common;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem.Exceptions;

public class EventBusMessageException : Exception
{
    public string? Code { get; }
    public BusMessageData? ErrorData { get; }
    public EventBusMessageException(string code, string message) : base(message)
    {
        Code = code;
    }
    public EventBusMessageException(string code, BusMessageData errorData, string message) : this(code, message)
    {
        ErrorData = errorData;
    }

}
