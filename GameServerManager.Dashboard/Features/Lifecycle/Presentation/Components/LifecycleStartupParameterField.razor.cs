using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SwizzleV;
using System.Runtime.CompilerServices;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components;

public partial class LifecycleStartupParameterField : ComponentBase
{
    [Parameter] 
    public GameStartupParameterEntity GameStartupParameter { get; set; } = default!;
    [Parameter]
    public string InitialValue { get; set; } = default!;
    [Inject] public ISwizzleFactory SwizzleFactory { get; set; } = default!;

    public MudSelect<string>? MudSelectRef { get; set; }
    public MudNumericField<int>? MudNumericFieldIntRef { get; set; }
    public MudNumericField<double>? MudNumericFieldDecimalRef { get; set; }
    public MudTextField<string>? MudTextFieldRef { get; set; }
    public MudSwitch<string>? MudSwitchRef { get; set; }

    private LifecycleStartupParameterFieldViewModel _viewModel = default!;
    protected override async Task OnInitializedAsync()
    {
        // Create or Get Exisintg Hook Binding
        var articleVMHook = SwizzleFactory.
            CreateOrGet<LifecycleStartupParameterFieldViewModel>(() => this, ShouldUpdate);
        // Get View Model Type Instance of the Hook
        _viewModel = articleVMHook.GetViewModel<LifecycleStartupParameterFieldViewModel>()!;

        _viewModel.Parameter = GameStartupParameter;
        _viewModel.InitialValue = InitialValue;
        _viewModel.Value = InitialValue;

    }
    private Task ShouldUpdate() => InvokeAsync(StateHasChanged);

    private int GetMaxLength() => _viewModel.Parameter.Validation?.MaxLength ?? 524288;


    private bool IsTouched => _viewModel.InitialValue != _viewModel.Value;
    private int ValueInt
    {       
        get
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Value) ? int.Parse(_viewModel.Value) : 0;
        }
        set { _viewModel.Value = value.ToString(); }
    }

    private double ValueDecimal
    {
        get
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Value) ? double.Parse(_viewModel.Value) : 0;
        }
        set { _viewModel.Value = value.ToString(); }
    }

    private async Task Save() => await _viewModel.Save();
    private void Reset()
    {
        if (MudSelectRef != default && MudSelectRef.Touched)
            _ = MudSelectRef.ResetAsync();
        else if (MudNumericFieldIntRef != default && MudNumericFieldIntRef.Touched)
            _ = MudNumericFieldIntRef.ResetAsync();
        else if (MudNumericFieldDecimalRef != default && MudNumericFieldDecimalRef.Touched)
            _ = MudNumericFieldDecimalRef.ResetAsync();
        else if (MudTextFieldRef != default && MudTextFieldRef.Touched)
            _ = MudTextFieldRef.ResetAsync();
        else if (MudSwitchRef != default && MudSwitchRef.Touched)
            _ = MudSwitchRef.ResetAsync();
    }
}
