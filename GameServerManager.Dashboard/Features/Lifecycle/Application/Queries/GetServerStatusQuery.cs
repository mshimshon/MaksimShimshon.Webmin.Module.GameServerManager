using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using MedihatR;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Queries;

public record GetServerStatusQuery : IRequest<ServerInfoEntity>;
