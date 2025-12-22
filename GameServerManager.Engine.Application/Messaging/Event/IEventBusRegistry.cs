using GameServerManager.Engine.Domain.Messaging.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine.Application.Messaging.Event;

public interface IEventBusRegistry
{
    IReadOnlyList<EventTypeEntity> GetRegistryFor( string id);
    IReadOnlyList<string> GetAllAvailableIds();
    void Register(string id, EventTypeEntity handlerEntity);
    void UnRegister(string id, EventTypeEntity handlerEntity);
}
