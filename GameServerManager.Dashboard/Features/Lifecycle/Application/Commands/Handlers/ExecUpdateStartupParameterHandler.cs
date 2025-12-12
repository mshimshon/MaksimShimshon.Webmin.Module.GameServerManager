using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Actions;
using GameServerManager.Dashboard.Features.Lifecycle.Application.Pulses.Stores;
using GameServerManager.Dashboard.Shared.Exceptions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Enums;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Commands.Handlers;

public class ExecUpdateStartupParameterHandler : IRequestHandler<ExecUpdateStartupParameterCommand>
{
    private readonly ILifecycleServices _lifecycleServices;
    private readonly IDispatcher _dispatcher;
    private readonly IStateAccessor<LifecycleGameInfoState> _gameinfoStateAccessor;

    public ExecUpdateStartupParameterHandler(ILifecycleServices lifecycleServices, IDispatcher dispatcher, IStateAccessor<LifecycleGameInfoState> gameinfoStateAccessor)
    {
        _lifecycleServices = lifecycleServices;
        _dispatcher = dispatcher;
        _gameinfoStateAccessor = gameinfoStateAccessor;
    }
    public async Task Handle(ExecUpdateStartupParameterCommand request, CancellationToken cancellationToken) 
       {
        try
        {
            await _lifecycleServices.UpdateStartupParameterAsync(request.Key, request.Value, cancellationToken);

            if (_gameinfoStateAccessor.State.StartupParameters.ContainsKey(request.Key))
                _gameinfoStateAccessor.State.StartupParameters[request.Key] = request.Value;
            else
                _gameinfoStateAccessor.State.StartupParameters.Add(request.Key, request.Value);

            await _dispatcher.Prepare<LifecycleServerGameInfoUpdatedAction>()
                .With(p => p.GameInfo, _gameinfoStateAccessor.State.GameInfo)
                .DispatchAsync();
        }
        catch (WebServiceException ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, ex.Message)
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
        }
        catch
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, "Unknown Error, Please contact admins if persistent.")
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
        }
    }
}
