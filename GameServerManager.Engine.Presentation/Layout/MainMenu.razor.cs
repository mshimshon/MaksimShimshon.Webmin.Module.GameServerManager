using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Engine.Presentation.Layout;

public partial class MainMenu : ComponentBase
{
    [Inject] IDispatcher Dispatcher { get; set; } = default!;
    protected override Task OnAfterRenderAsync(bool firstRender)
    {

    }
}
