using CoreMap;
using GameServerManager.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class AllowedValueResponseToAllowedValueEntity : ICoreMapHandler<GameStartupParameterAllowedValueResponse, StartupParameterAllowedValue>
{
    public StartupParameterAllowedValue Handler(GameStartupParameterAllowedValueResponse data, ICoreMap alsoMap)
        => new(data.Value, data.Label);
}
