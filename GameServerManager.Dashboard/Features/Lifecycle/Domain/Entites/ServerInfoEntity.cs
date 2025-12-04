using GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;

namespace GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;

public record ServerInfoEntity
{
    public Status Status { get; init; } = Status.Stopped;
    public string? SteamAppId { get; init; }
    public string Name { get; init; } = default!;
    public string Ip { get; init; } = default!;
    public string Port { get; init; } = default!;
    public TimeSpan Uptime { get; init; }
    public string Pid { get; init; }
}
