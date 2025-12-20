using GameServerManager.Core.Abstractions.Exceptions;
using GameServerManager.Core.Abstractions.Notification.Pulses.Actions;
using GameServerManager.Core.Abstractions.Notification.Pulses.Enums;
using GameServerManager.Features.Lifecycle.Application.Services;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Commands.Handlers;

public class ExecStopServerHandler : IRequestHandler<ExecStopServerCommand>
{
    private readonly ILifecycleServices _lifecycleServices;
    private readonly IDispatcher _dispatcher;

    public ExecStopServerHandler(ILifecycleServices lifecycleServices, IDispatcher dispatcher)
    {
        _lifecycleServices = lifecycleServices;
        _dispatcher = dispatcher;
    }
    public async Task Handle(ExecStopServerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _lifecycleServices.ServerStopAsync();
        }
        catch(WebServiceException ex)
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
