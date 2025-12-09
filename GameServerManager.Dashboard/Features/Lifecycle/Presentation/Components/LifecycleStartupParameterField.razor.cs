using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;
using Microsoft.AspNetCore.Components;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components;

public partial class LifecycleStartupParameterField : ComponentBase
{
    [Parameter] 
    public GameStartupParameterEntity GameStartupParameter { get; set; } = default!;
    
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;

    private LifecycleStartupParameterFieldViewModel _viewModel = default!;
    protected override async Task OnInitializedAsync()
    {
        // Create or Get Exisintg Hook Binding
        var articleVMHook = SwizzleFactory.CreateOrGet<LifecycleStartupParameterFieldViewModel>(() => this, ShouldUpdate);
        // Get View Model Type Instance of the Hook
        _viewModel = articleVMHook.GetViewModel<LifecycleStartupParameterFieldViewModel>()!;

        _viewModel.Parameter = GameStartupParameter;
    }
    private Task ShouldUpdate() => InvokeAsync(StateHasChanged);

    private int GetMaxLength() => _viewModel.Parameter.Validation?.MaxLength ?? 524288;
}
