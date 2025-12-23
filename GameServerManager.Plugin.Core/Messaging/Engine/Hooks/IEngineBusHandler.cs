namespace GameServerManager.Plugin.Core.Messaging.Engine.Hooks;

public interface IEngineBusHandler
{
    Task<EngineBusResponse> HandleAsync(IEngineBusMessage engineBusMessage);

}
