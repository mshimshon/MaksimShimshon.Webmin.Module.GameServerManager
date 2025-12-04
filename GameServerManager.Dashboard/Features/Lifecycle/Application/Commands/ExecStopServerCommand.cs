using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using MedihatR;

namespace GameServerManager.Dashboard.Features.Lifecycle.Applcation.Commands;

public record ExecStopServerCommand : IRequest<ServerInfoEntity>;
