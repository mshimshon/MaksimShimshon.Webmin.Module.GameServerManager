using GameServerManager.Dashboard.Features.Lifecycle.Applcation.Services;
using GameServerManager.Dashboard.Shared.Exceptions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Actions;
using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Enums;
using MedihatR;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Queries.Handlers;

public class GetStartupParametersHandler : IRequestHandler<GetStartupParametersQuery, Dictionary<string, string>>
{
    private readonly ILifecycleServices _lifecycleServices;
    private readonly IDispatcher _dispatcher;

    public GetStartupParametersHandler(ILifecycleServices lifecycleServices, IDispatcher dispatcher)
    {
        _lifecycleServices = lifecycleServices;
        _dispatcher = dispatcher;
    }
    public async Task<Dictionary<string, string>> Handle(GetStartupParametersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _lifecycleServices.GetServerStartupParametersAsync(cancellationToken);
        }
        catch (WebServiceException ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, ex.Message)
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            return default;
        }
        catch (Exception ex)
        {
            await _dispatcher.Prepare<SendToastNotificationAction>()
                .With(p => p.Message, "Unknown Error, Please contact admins if persistent.")
                .With(p => p.Color, ToastColor.Error)
                .DispatchAsync();
            Console.WriteLine(ex.Message);
            return default;
        }
    }
}
