namespace GameServerManager.Plugin.Core.Messaging.Engine.Hooks;

public interface IEngineBus
{
    Task<EngineBusResponse[]> ExecAsync(IEngineBusMessage engineBusRender, CancellationToken cancellationToken = default);

}
