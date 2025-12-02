using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;
using Microsoft.AspNetCore.Components;
using StatePulse.Net;
using SwizzleV;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Pages.ViewModels;

public class WebminModulePageViewModel
{
    private bool _loading = false;
    public bool Loading
    {
        get => _loading || WebminModalStore.IsLoading;
        private set
        {
            if (value != _loading)
                _ = _swizzleViewModel.SpreadChanges(() => this);
            _loading = value;
        }
    }
    private readonly ISwizzleViewModel _swizzleViewModel;
    private readonly IStatePulse _statePulse;

    public WebminModuleFrameState WebminModalStore => _statePulse.StateOf<WebminModuleFrameState>(() => this, OnUpdate);
    private async Task OnUpdate() => await _swizzleViewModel.SpreadChanges(() => this);
    public WebminModulePageViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
    }

}
