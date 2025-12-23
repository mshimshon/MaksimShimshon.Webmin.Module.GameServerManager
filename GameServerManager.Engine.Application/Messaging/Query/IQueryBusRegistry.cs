using GameServerManager.Engine.Domain.Messaging.Event;

namespace GameServerManager.Engine.Application.Messaging.Query;

public interface IQueryBusRegistry
{
    EventTypeEntity GetRegistryFor(string id);
    IReadOnlyList<string> GetAllAvailableIds();
    void Register(string id, EventTypeEntity handlerEntity);
    void UnRegister(string id);
}
