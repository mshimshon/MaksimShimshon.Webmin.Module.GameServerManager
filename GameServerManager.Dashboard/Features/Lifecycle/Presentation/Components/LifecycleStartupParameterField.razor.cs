using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components;

public partial class LifecycleStartupParameterField : ComponentBase
{
    [Parameter] 
    public GameStartupParameterEntity GameStartupParameter { get; set; } = default!;
    
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;

    public MudSelect<string> MudSelectRef { get; set; }
    public MudNumericField<int> MudNumericFieldIntRef { get; set; }
    public MudNumericField<float> MudNumericFieldDecimalRef { get; set; }
    public MudTextField<string> MudTextFieldRef { get; set; }

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

    private int ValueInt
    {
        get => !string.IsNullOrWhiteSpace(_viewModel.Value) ? int.Parse(_viewModel.Value) : 0;
        set { _viewModel.Value = value.ToString(); }
    }
    private float ValueDecimal
    {
        get => !string.IsNullOrWhiteSpace(_viewModel.Value) ? float.Parse(_viewModel.Value) : 0;
        set { _viewModel.Value = value.ToString(); }
    }
}
