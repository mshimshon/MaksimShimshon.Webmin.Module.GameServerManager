using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Shared.Exceptions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Enums;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Commands.Handlers;

public class ExecStopServerHandler : IRequestHandler<ExecStopServerCommand, ServerInfoEntity?>
{
    private readonly ILifecycleServices _lifecycleServices;
    private readonly IDispatcher _dispatcher;

    public ExecStopServerHandler(ILifecycleServices lifecycleServices, IDispatcher dispatcher)
    {
        _lifecycleServices = lifecycleServices;
        _dispatcher = dispatcher;
    }
    public async Task<ServerInfoEntity?> Handle(ExecStopServerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _lifecycleServices.ServerStopAsync();
        }
        catch(WebServiceException ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, ex.Message)
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            return default;
        }
        catch
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, "Unknown Error, Please contact admins if persistent.")
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            return default;
        }

    }
}
