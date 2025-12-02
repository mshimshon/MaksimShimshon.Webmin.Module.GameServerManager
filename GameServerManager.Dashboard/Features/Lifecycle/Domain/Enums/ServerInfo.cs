using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;

namespace GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;

public record ServerInfo
{
    public Status Status { get; init; } = Status.Stopped;
    public string? SteamAppId { get; init; }
    public string Name { get; init; } = default!;
    public string Ip { get; set; } = default!;
    public string Port { get; set; } = default!;
    public TimeSpan Uptime { get; set; }
}
