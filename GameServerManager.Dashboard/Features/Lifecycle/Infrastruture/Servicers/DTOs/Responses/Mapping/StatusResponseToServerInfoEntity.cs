using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses.Mapping;

public class StatusResponseToServerInfoEntity : ICoreMapHandler<StatusResponse, ServerInfoEntity>
{
    public ServerInfoEntity Handler(StatusResponse data, ICoreMap alsoMap)
    {
        Status currentStatus = Status.Unknown;
        if (string.Equals(data.Status, "started", StringComparison.InvariantCultureIgnoreCase))
            currentStatus = Status.Running;
        else if (string.Equals(data.Status, "stopped", StringComparison.InvariantCultureIgnoreCase))
            currentStatus = Status.Stopped;

        return new ServerInfoEntity()
        {
            Status = currentStatus,
            Port = data.Server?.Port.ToString() ?? "????",
            Name = data.Server?.Name ?? "Unknown",
            LastUpdate = data.Timestamp,
            GameInfo = alsoMap.Map(data.GameInfo).To<GameInfoEntity>() 
        };
    }
}


