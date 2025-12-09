using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;

public class LifecycleStartupParameterFieldViewModel
{
    private bool _loading = false;
    public bool Loading
    {
        get => _loading || GameInfoState.GameInfo == default;
        private set
        {
            if (value != _loading)
                _ = _swizzleViewModel.SpreadChanges(() => this);
            _loading = value;
        }
    }

    private readonly ISwizzleViewModel _swizzleViewModel;
    private readonly IStatePulse _statePulse;
    private readonly IDispatcher _dispatcher;

    public LifecycleGameInfoState GameInfoState => _statePulse.StateOf<LifecycleGameInfoState>(() => this, OnStateChanged);

    public GameStartupParameterEntity Parameter { get; set; } = default!;

    public string Value { get; set; } = string.Empty;
    private bool HasLoaded { get; set; }
    public bool HasValidation => Parameter.Validation != default;
    public bool IsList => Parameter.Validation?.AllowedValues != default && 
        Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.List;
    public bool IsDecimal => Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.Decimal;
    public bool IsInt => Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.Int;
    public bool IsNumber => IsDecimal || IsInt;
    private async Task OnStateChanged()
    {
        CheckInitialValue();
        await _swizzleViewModel.SpreadChanges(() => this);
    }
    public LifecycleStartupParameterFieldViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse, IDispatcher dispatcher)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
        _dispatcher = dispatcher;
        HasLoaded = GameInfoState.SavedParametersLoaded;
        CheckInitialValue();
    }

    private void CheckInitialValue()
    {
        if (HasLoaded != GameInfoState.SavedParametersLoaded && GameInfoState.SavedParametersLoaded)
        {
            PullValueFromSavedParameters();
        }
    }

    private void PullValueFromSavedParameters()
    {
        if (!GameInfoState.StartupParameters.ContainsKey(Parameter.Key.Key))
            Value = Parameter.DefaultValue ?? string.Empty;
        else
            Value = GameInfoState.StartupParameters[Parameter.Key.Key];
    }

    public void OnValueChanged(ChangeEventArgs e)
    {

    }


    public void Save()
    {

    }

    public void Reset()  => PullValueFromSavedParameters();
}
