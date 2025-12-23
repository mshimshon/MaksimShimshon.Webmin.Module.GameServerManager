namespace GameServerManager.Engine.Infrastructure.Circuit;

public sealed record CircuitIdentityDto
{
    public string Id { get; init; } = default!;
    public IServiceProvider? ServiceProvider { get; set; }
    public bool IsLinkUp { get; set; }
}
