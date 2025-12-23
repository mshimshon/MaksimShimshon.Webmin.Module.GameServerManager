namespace GameServerManager.Engine.Application.Messaging.Query;

public interface IQueryBusRegistry
{
    Type GetRegistryFor(string id);
    IReadOnlyList<string> GetAllAvailableIds();
    void Register(string id, Type handlerType);
    void UnRegister(string id);
}
