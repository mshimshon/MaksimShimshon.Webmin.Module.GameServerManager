using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;
using Microsoft.AspNetCore.Components;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages;

public partial class LifecyclePage : IAsyncDisposable
{
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;

    private LifecyclePageViewModel _viewModel = default!;
    protected override async Task OnInitializedAsync()
    {
        // Create or Get Exisintg Hook Binding
        var articleVMHook = SwizzleFactory.CreateOrGet<LifecyclePageViewModel>(() => this, ShouldUpdate);
        // Get View Model Type Instance of the Hook
        _viewModel = articleVMHook.GetViewModel<LifecyclePageViewModel>()!;
    }
    private Task ShouldUpdate() => InvokeAsync(StateHasChanged);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) 
            await _viewModel.StartListening();
    }

    public async ValueTask DisposeAsync()
    {
        await _viewModel.StopListening();
    }
}
