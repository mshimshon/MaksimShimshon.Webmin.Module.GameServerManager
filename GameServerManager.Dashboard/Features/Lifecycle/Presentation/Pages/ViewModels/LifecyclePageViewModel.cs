using GameServerManager.Dashboard.Features.Lifecycle.Abstractions.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Pulses.Stores;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Shared.Webmin.Presentation.Pulses.Stores;
using StatePulse.Net;
using SwizzleV;
using System.Runtime.CompilerServices;

namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;

public class LifecyclePageViewModel
{
    private bool _loading = false;
    public bool Loading
    {
        get => _loading;
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

    public LifecycleServerState ServerState => _statePulse.StateOf<LifecycleServerState>(() => this, OnUpdate);
    public LifecycleGameInfoState GameInfoState => _statePulse.StateOf<LifecycleGameInfoState>(() => this, OnUpdate);
    private async Task OnUpdate() => await _swizzleViewModel.SpreadChanges(() => this);
    public LifecyclePageViewModel(ISwizzleViewModel swizzleViewModel, IStatePulse statePulse, IDispatcher dispatcher)
    {
        _swizzleViewModel = swizzleViewModel;
        _statePulse = statePulse;
        _dispatcher = dispatcher;
    }

    public async Task Start()
    {
        Loading = true;
        Console.WriteLine("Launching Server...");
        await _dispatcher.Prepare<LifecycleServerStartAction>().DispatchAsync();
        Loading = false;
    }

    public async Task Stop()
    {
        Loading = true;
        Console.WriteLine("Stopping Server...");
        await _dispatcher.Prepare<LifecycleServerStopAction>().DispatchAsync();
        Loading = false;
    }
    public bool IsRunning() => ServerState.ServerInfo != default && ServerState.ServerInfo.Status == Domain.Enums.Status.Running;
    public bool IsStopped() => ServerState.ServerInfo != default && ServerState.ServerInfo.Status == Domain.Enums.Status.Stopped;
    public bool IsRestarting() => ServerState.ServerInfo != default && ServerState.ServerInfo.Status == Domain.Enums.Status.Running;
    public bool IsFailed() => ServerState.ServerInfo != default && ServerState.ServerInfo.Status == Domain.Enums.Status.Failed;
    public bool IsWaiting() => ServerState.ServerInfo == default || ServerState.ServerInfo.Status == Domain.Enums.Status.Unknown;


    public async Task StartListening()
    {
    }

    public async Task StopListening()
    {

    }
}
