using GameServerManager.Plugin.Core.Messaging.EventSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServerManager.Engine.Application.Messaging.Event.Exceptions;

public class NoEventBusIdEntryException : Exception
{
    public string Id { get; }
    public NoEventBusIdEntryException(string id) : base($"({id}) is not a registered event.")
    {
        Id = id;
    }
}
