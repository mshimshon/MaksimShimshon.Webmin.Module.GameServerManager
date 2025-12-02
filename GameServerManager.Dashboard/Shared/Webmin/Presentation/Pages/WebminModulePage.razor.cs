using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Actions;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;
using SwizzleV;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages;

public partial class WebminModulePage : ComponentBase
{
    [Parameter] 
    public string Module { get; set; } = default!;
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;
    [Inject] public IDispatcher Dispatcher { get; set; } = default!;
    private WebminModulePageViewModel _viewModel = default!;
    protected override async Task OnInitializedAsync()
    {
        
        //// Create or Get Exisintg Hook Binding
        var vmHook = SwizzleFactory.CreateOrGet<WebminModulePageViewModel>(() => this, ShouldUpdate);
        //// Get View Model Type Instance of the Hook
        _viewModel = vmHook.GetViewModel<WebminModulePageViewModel>()!;

    }
    protected override async Task OnParametersSetAsync()
    {
        await Dispatcher.Prepare<WebminInitializeModuleAction>().With(p => p.ModuleName, Module).DispatchAsync();
    }
    private Task ShouldUpdate() => InvokeAsync(StateHasChanged);
}
