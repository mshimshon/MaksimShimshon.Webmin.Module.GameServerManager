using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Core.Layout;

public partial class MainMenu
{
    [Inject] IDispatcher Dispatcher { get; set; } = default!;

}
