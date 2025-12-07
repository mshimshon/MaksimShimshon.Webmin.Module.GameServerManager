using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using StatePulse.Net;
using SwizzleV;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Components.ViewModels;

public class LifecycleSystemResourcesStatusViewModel
{
    private bool _loading = false;
    public bool Loading
    {
        get => _loading || SystemState.SystemInfo == default;
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


    public LifecycleSystemState SystemState => _statePulse.StateOf<LifecycleSystemState>(() => this, OnUpdate);
    private async Task OnUpdate()
    {

        await _swizzleViewModel.SpreadChanges(() => this);
    }
    public LifecycleSystemResourcesStatusViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse, IDispatcher dispatcher)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
        _dispatcher = dispatcher;

    }
}
