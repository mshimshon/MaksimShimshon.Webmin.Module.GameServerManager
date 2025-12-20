using CoreMap;
using GameServerManager.Features.Lifecycle.Domain.Entites;
using GameServerManager.Features.Lifecycle.Domain.Enums;
using GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping;

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
            GameInfo = alsoMap.Map(data.GameInfo).To<GameInfoEntity>(),
            SystemInfo = data.Resources != default && data.Resources.Memory != default && data.Resources.Cpu != default && data.Resources.Storage != default ? alsoMap.Map(data.Resources).To<SystemInfoEntity>() : default
        };
    }
}


