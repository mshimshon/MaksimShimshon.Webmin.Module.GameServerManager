using GameServerManager.Core.Abstractions.Event;
using GameServerManager.Core.Abstractions.Exceptions;
using GameServerManager.Core.Abstractions.Notification.Pulses.Actions;
using GameServerManager.Core.Abstractions.Notification.Pulses.Enums;
using GameServerManager.Features.Lifecycle.Application.Events;
using GameServerManager.Features.Lifecycle.Application.Services;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Commands.Handlers;

public class ExecStartServerHandler : IRequestHandler<ExecStartServerCommand>
{
    private readonly ILifecycleServices _lifecycleServices;
    private readonly IDispatcher _dispatcher;
    private readonly IEventBus _eventBus;

    public ExecStartServerHandler(ILifecycleServices lifecycleServices, IDispatcher dispatcher, IEventBus eventBus)
    {
        _lifecycleServices = lifecycleServices;
        _dispatcher = dispatcher;
        _eventBus = eventBus;
    }
    public async Task Handle(ExecStartServerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _eventBus.PublishAsync(new LifecycleEventMessageNoData(LifecycleEvents.ServerStartBegin));
            await _lifecycleServices.ServerStartAsync();
        }
        catch (WebServiceException ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, ex.Message)
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            await _eventBus.PublishAsync(new LifecycleEventMessage(LifecycleEvents.ServerStartFailed, ex));

        }
        catch (Exception ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, "Unknown Error, Please contact admins if persistent.")
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            await _eventBus.PublishAsync(new LifecycleEventMessage(LifecycleEvents.ServerStartFailed, ex));

        }

    }
}
