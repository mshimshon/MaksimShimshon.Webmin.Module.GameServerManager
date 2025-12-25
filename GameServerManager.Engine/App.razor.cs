using LunaticPanel.Engine.Services.CircuitControl;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;

namespace GameServerManager.Engine;

public partial class App : ComponentBase
{
    [Inject] private IServiceProvider ServiceProvider { get; set; } = default!;
    [Inject] private CircuitRegistry CircuitRegistry { get; set; } = default!;
    protected override void OnInitialized()
    {
        CircuitRegistry.SelfCircuitRegistration(ServiceProvider);
    }
}
