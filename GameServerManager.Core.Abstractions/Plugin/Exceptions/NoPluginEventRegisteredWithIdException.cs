using GameServerManager.Core.Abstractions.Plugin;

namespace GameServerManager.Core.Abstractions.Plugin.Exceptions;

public class NoPluginEventRegisteredWithIdException : Exception
{
    public IPluginEventBusMessageRequest PluginEventBusMessage { get; }
    public NoPluginEventRegisteredWithIdException(IPluginEventBusMessageRequest evt) : base($"({evt.GetEventId()}) is not a registered event.")
    {
        PluginEventBusMessage = evt;
    }
}
