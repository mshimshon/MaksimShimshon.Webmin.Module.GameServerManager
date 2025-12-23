using GameServerManager.Plugin.Core.Messaging.EngineBus;
using GameServerManager.Plugin.Dashboard.Contracts;
using Microsoft.AspNetCore.Components;

namespace GameServerManager.Plugin.Dashboard;

[EngineBusId("Engine.Layout.Menu.Fetch")]
internal class MainMenuEngineBusHandler : IEngineBusHandler
{
    public Task<EngineBusResponse> HandleAsync(IEngineBusMessage engineBusMessage)
    {
        RenderFragment fragment = builder =>
        {
            builder.OpenComponent<MenuItems>(0);
            builder.CloseComponent();
        };
        return Task.FromResult(new EngineBusResponse(fragment, new MenuItemDto()));
    }
}
