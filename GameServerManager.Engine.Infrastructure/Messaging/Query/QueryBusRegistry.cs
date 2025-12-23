using GameServerManager.Engine.Application.Messaging.Event.Exceptions;
using GameServerManager.Engine.Application.Messaging.Query;
using GameServerManager.Engine.Domain.Messaging.Event;

namespace GameServerManager.Engine.Infrastructure.Messaging.Query;

internal class QueryBusRegistry : IQueryBusRegistry
{
    private readonly Dictionary<string, EventTypeEntity> _internalRegistryEventTypes = new();
    private readonly object _lock = new();

    public IReadOnlyList<string> GetAllAvailableIds()
    {
        lock (_lock)
        {
            return _internalRegistryEventTypes.Keys.ToList().AsReadOnly()!;
        }
    }

    public EventTypeEntity GetRegistryFor(string id)
    {
        id = id.ToLower();
        lock (_lock)
        {
            return _internalRegistryEventTypes[id] ?? throw new QueryBusNotFoundException(id);
        }
    }

    public void Register(string id, EventTypeEntity handlerEntity)
    {
        id = id.ToLower();

        lock (_lock)
        {
            if (_internalRegistryEventTypes.ContainsKey(id))
                throw new QueryBusMultipleHandlerException(id);
            _internalRegistryEventTypes[id] = handlerEntity;
        }
    }

    public void UnRegister(string id)
    {
        id = id.ToLower();

        lock (_lock)
        {
            if (!_internalRegistryEventTypes.ContainsKey(id))
                _internalRegistryEventTypes.Remove(id);
        }
    }
}
