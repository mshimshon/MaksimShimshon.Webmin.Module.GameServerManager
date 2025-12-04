using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses.Mapping;

public class StatusGameInfoResponseToGameInfoEntity : ICoreMapHandler<StatusGameInfoResponse, GameInfoEntity>
{
    public GameInfoEntity Handler(StatusGameInfoResponse data, ICoreMap alsoMap) => new GameInfoEntity() {
        ManualModUpload = data.ManualModUpload, 
        Modding = data.Modding, 
        Name = data.Name, 
        SteamInfo = data.Steam && !string.IsNullOrWhiteSpace(data.SteamAppId) ? new SteamGameId(data.SteamAppId, data.Modding && data.Workshop) : default 
         
    };
}
