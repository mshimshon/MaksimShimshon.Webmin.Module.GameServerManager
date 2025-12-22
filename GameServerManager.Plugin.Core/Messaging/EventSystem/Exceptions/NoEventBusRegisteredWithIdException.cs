using GameServerManager.Plugin.Core.Messaging.EventSystem;

namespace GameServerManager.Plugin.Core.Messaging.EventSystem.Exceptions;

public class NoEventBusRegisteredWithIdException : Exception
{
    public IEventBusMessage PluginEventBusMessage { get; }
    public NoEventBusRegisteredWithIdException(IEventBusMessage evt) : base($"({evt.GetId()}) is not a registered event.")
    {
        PluginEventBusMessage = evt;
    }
}
