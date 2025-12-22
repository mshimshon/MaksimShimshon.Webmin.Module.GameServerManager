using GameServerManager.Plugin.Core.Messaging.EventSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Plugin.Core.Messaging.QuerySystem;

public interface IQueryBus
{
    IReadOnlyCollection<string> GetAllQueryIds();
    Task<QueryBusMessageResponse> QueryAsync(IQueryBusMessage qry);
}
