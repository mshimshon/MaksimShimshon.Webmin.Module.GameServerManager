using GameServerManager.Features.Lifecycle.Domain.Enums;

namespace GameServerManager.Features.Lifecycle.Domain.Entites;

public sealed record GameStartupParameterConstraintTypeEntity
{
    public string Key { get; init; } = default!;
    public StartupParameterConstraintType Constraint { get; init; }
    public string Message { get; init; } = default!;
}
