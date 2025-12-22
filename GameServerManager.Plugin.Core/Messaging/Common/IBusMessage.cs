using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Plugin.Core.Messaging.Common;

public interface IBusMessage
{
    string GetId();
    object? GetData();
    Guid GetMessageId();
}
