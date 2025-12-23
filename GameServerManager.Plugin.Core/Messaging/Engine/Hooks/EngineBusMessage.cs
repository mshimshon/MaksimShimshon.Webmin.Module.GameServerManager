using Microsoft.AspNetCore.Components;

namespace GameServerManager.Plugin.Core.Messaging.Engine.Hooks;

public sealed class EngineBusMessage : IEngineBusMessage
{
    public RenderFragment RenderFragment { get; }
    public Guid Id { get; }
    public string BaseId { get; }
    public string Type { get; }

    public EngineBusMessage(string baseId, string type, RenderFragment renderFragment)
    {
        Id = Guid.NewGuid();
        BaseId = baseId;
        Type = type;
        RenderFragment = renderFragment;
    }

    public string GetId() => $"{BaseId}.{Type}";

    public object GetData() => RenderFragment;
    public Guid GetMessageId() => Id;
}
