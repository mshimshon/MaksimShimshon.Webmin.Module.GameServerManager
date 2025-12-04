using GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Enums;
using StatePulse.Net;

namespace GameServerManager.Dashboard.Shared.Notification.Abstraction.Pulses.Actions;

public record SendToastNotificationAction : IAction
{
    public string Message { get; set; } = default!;
    public ToastColor Color { get; set; } = ToastColor.Info;
}
