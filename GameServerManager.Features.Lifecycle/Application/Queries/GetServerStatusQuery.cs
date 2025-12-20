using GameServerManager.Features.Lifecycle.Domain.Entites;
using MedihatR;

namespace GameServerManager.Features.Lifecycle.Application.Queries;

public record GetServerStatusQuery : IRequest<ServerInfoEntity>;
