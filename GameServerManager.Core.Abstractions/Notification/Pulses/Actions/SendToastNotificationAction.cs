using GameServerManager.Core.Abstractions.Notification.Pulses.Enums;
using StatePulse.Net;

namespace GameServerManager.Core.Abstractions.Notification.Pulses.Actions;

public record SendToastNotificationAction : IAction
{
    public string Message { get; set; } = default!;
    public ToastColor Color { get; set; } = ToastColor.Info;
}
