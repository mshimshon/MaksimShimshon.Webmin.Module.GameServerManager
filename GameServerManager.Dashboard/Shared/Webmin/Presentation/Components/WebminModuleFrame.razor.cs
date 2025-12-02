using GameServerManager.Dashboard.Shared.Webmin.Presentation.Components.ViewModels;
using Microsoft.AspNetCore.Components;
using SwizzleV;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Components;

public partial class WebminModuleFrame : ComponentBase
{
    [Parameter]
    public string ModuleName { get; set; } = default!;
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;

    private WebminModuleFrameViewModel _viewModel = default!;
    protected override async Task OnInitializedAsync()
    {
        // Create or Get Exisintg Hook Binding
        var articleVMHook = SwizzleFactory
            .CreateOrGet<WebminModuleFrameViewModel>(() => this, ShouldUpdate);
        _viewModel = articleVMHook.GetViewModel<WebminModuleFrameViewModel>()!;
        _viewModel.ModuleName = ModuleName;
        await _viewModel.LoadAsync();
    }
    private Task ShouldUpdate() => InvokeAsync(StateHasChanged);
}
