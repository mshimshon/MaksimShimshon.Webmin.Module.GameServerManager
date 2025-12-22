namespace GameServerManager.Core.Abstractions.Plugin;

public interface IPluginEventBusHandler
{
    Task<PluginEventBusMessageResponse> HandleAsync(IPluginEventBusMessageRequest evt);
}
