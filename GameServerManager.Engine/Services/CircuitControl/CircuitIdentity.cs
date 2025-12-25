using System;
using System.Collections.Generic;
using System.Text;

namespace LunaticPanel.Engine.Services.CircuitControl;

internal sealed record CircuitIdentity
{
    public string Id { get; init; } = default!;
    public IServiceProvider? ServiceProvider { get; set; }
    public bool IsLinkUp { get; set; }
}
