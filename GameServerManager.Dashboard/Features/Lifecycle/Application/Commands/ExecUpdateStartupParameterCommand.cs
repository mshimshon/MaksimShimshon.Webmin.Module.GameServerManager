using MedihatR;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Commands;

public record ExecUpdateStartupParameterCommand : IRequest
{
    public string Key { get; init; } = default!;
    public string Value { get; init; } = default!;
}
