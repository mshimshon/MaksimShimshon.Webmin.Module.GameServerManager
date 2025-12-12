using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;
using SwizzleV;
using System.Runtime.CompilerServices;

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
    public string InitialValue { get; set; } = string.Empty;
    public bool HasValidation => Parameter.Validation != default;
    public bool IsList => Parameter.Validation?.AllowedValues != default && 
        Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.List;
    public bool IsDecimal => Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.Decimal;
    public bool IsInt => Parameter.Key.StartupParameterType == Domain.Enums.StartupParameterType.Int;
    public bool IsNumber => IsDecimal || IsInt;
    private async Task OnStateChanged()
    {
        await _swizzleViewModel.SpreadChanges(() => this);
    }
    public LifecycleStartupParameterFieldViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse, IDispatcher dispatcher)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
        _dispatcher = dispatcher;
    }

    public async Task Save()
    {
        await _dispatcher.Prepare<LifecycleUpdateStartupParameterAction>()
            .With(p => p.Key, Parameter.Key.Key)
            .With(p => p.Value, Value)
            .DispatchAsync();
    }

    public void Reset() {
        Console.WriteLine($"{Value} = {InitialValue}");
        Value = InitialValue;
        _ = OnStateChanged();
    }
    public bool Validate()
    {

        return true;
    }
}
