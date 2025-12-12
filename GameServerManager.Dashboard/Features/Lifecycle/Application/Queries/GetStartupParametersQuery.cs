using MedihatR;

namespace GameServerManager.Dashboard.Features.Lifecycle.Application.Queries;

public record GetStartupParametersQuery : IRequest<Dictionary<string, string>>;
