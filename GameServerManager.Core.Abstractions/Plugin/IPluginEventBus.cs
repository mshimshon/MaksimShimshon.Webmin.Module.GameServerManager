namespace GameServerManager.Core.Abstractions.Plugin;

public interface IPluginEventBus
{
    IReadOnlyCollection<string> GetAllEventIds();
    IReadOnlyCollection<Type> GetAllHandlersByEventId(string eventId);
    Task<IReadOnlyCollection<PluginEventBusMessageResponse>> PublishAsync(IPluginEventBusMessageRequest evt)
}
