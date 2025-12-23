using Microsoft.AspNetCore.Components;

namespace GameServerManager.Engine.Presentation.Layout.Menu.Models;

public record MenuElementModel
{
    public int Position { get; init; }
    public RenderFragment Render { get; init; } = default!;
}
