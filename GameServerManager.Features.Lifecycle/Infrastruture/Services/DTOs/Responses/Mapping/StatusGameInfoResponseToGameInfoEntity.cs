using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;
using GameServerManager.Features.Lifecycle.Domain.Entites;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping;

public class StatusGameInfoResponseToGameInfoEntity : ICoreMapHandler<GameInfoResponse, GameInfoEntity>
{
    public GameInfoEntity Handler(GameInfoResponse data, ICoreMap alsoMap) => new GameInfoEntity() {
        ManualModUpload = data.ManualModUpload, 
        Modding = data.Modding, 
        Name = data.Name, 
        SteamInfo = data.Steam && !string.IsNullOrWhiteSpace(data.SteamAppId) ? new SteamGameId(data.SteamAppId, data.Modding && data.Workshop) : default,
        StartupParameters = alsoMap.MapEach(data.Parameters).To<GameStartupParameterEntity>()
    };
}
