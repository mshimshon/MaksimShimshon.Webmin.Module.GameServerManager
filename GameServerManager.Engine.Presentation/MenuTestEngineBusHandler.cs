using GameServerManager.Engine.Presentation.Layout.Menu;
using GameServerManager.Plugin.Core.Messaging.EngineBus;
using GameServerManager.Plugin.Dashboard.Contracts;
using Microsoft.AspNetCore.Components;

namespace GameServerManager.Engine.Presentation;

[EngineBusId("GameServerManager.Plugin.Dashboard.EngineBus.FetchAdditionalMenu")]
internal class MenuTestEngineBusHandler : IEngineBusHandler
{
    public Task<EngineBusResponse> HandleAsync(IEngineBusMessage engineBusMessage)
    {
        RenderFragment fragment = builder =>
        {
            builder.OpenComponent<MainMenu>(0);
            builder.CloseComponent();
        };
        return Task.FromResult(new EngineBusResponse(fragment, new MenuItemDto() { Position = 100 }));
    }
}
