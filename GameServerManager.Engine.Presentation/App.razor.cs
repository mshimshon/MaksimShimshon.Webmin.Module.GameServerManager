using GameServerManager.Engine.Presentation.Services;
using Microsoft.AspNetCore.Components;

namespace GameServerManager.Engine.Presentation;

public partial class App : ComponentBase
{
    [Inject] private IServiceProvider ServiceProvider { get; set; } = default!;
    [Inject] private CircuitRegistry CircuitRegistry { get; set; } = default!;
    protected override void OnInitialized()
    {
        CircuitRegistry.SelfCircuitRegistration(ServiceProvider);
    }
}
