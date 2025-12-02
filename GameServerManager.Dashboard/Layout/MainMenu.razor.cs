using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Layout;

public partial class MainMenu
{
    [Inject] IDispatcher Dispatcher { get; set; } = default!;

}
