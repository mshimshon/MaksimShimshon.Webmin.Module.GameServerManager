using MedihatR;

namespace GameServerManager.Features.Lifecycle.Application.Queries;

public record GetStartupParametersQuery : IRequest<Dictionary<string, string>>;
