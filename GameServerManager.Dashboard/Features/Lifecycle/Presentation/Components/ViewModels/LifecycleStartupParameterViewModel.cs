using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;
using StatePulse.Net;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;

public class LifecycleStartupParameterViewModel
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

    public LifecycleGameInfoState GameInfoState => _statePulse.StateOf<LifecycleGameInfoState>(() => this, OnUpdate);
    public Dictionary<string, List<GameStartupParameterEntity>> Parameters { get; private set; } = new();

    private async Task OnUpdate()
    {
        await GroupingParameters();
        await _swizzleViewModel.SpreadChanges(() => this);
    }
    public LifecycleStartupParameterViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse, IDispatcher dispatcher)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
        _dispatcher = dispatcher;
        _ = GroupingParameters();
    }
    public Task GroupingParameters()
    {
        Parameters = GameInfoState.GameInfo?.StartupParameters != default ? GameInfoState.GameInfo.StartupParameters
            .Where(p => !string.IsNullOrEmpty(p.Category))
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.ToList()) 
            : new();
        return Task.CompletedTask;
    }


}
