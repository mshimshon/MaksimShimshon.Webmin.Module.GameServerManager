using GameServerManager.Engine.Presentation.Layout.Menu.Contracts;
using GameServerManager.Engine.Presentation.Layout.Menu.Models;
using GameServerManager.Plugin.Core.Messaging.EngineBus;
using Microsoft.AspNetCore.Components;

namespace GameServerManager.Engine.Presentation.Layout.Menu;

public partial class MainMenu : ComponentBase
{
    [Inject] IEngineBus EngineBus { get; set; } = default!;
    ICollection<MenuElementModel> MenuItems { get; set; } = new List<MenuElementModel>();
    public async Task GetPluginMenuItems()
    {
        var message = new EngineBusMessage("Engine.Layout.Menu", "Fetch");
        var response = await EngineBus.ExecAsync(message);
        MenuItems = response
            .Select(p => (p.RenderFragment, p.Data!.GetDataAs<MenuItemMetadataDto>()!))
            .Select(p => new MenuElementModel() { Position = p.Item2.Position, Render = p.RenderFragment })
            .OrderBy(p => p.Position)
            .ToList();
        await InvokeAsync(StateHasChanged);
    }
}
