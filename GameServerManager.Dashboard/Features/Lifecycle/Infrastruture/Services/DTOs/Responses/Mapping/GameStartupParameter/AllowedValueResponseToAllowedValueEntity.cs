using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class AllowedValueResponseToAllowedValueEntity : ICoreMapHandler<GameStartupParameterAllowedValueResponse, StartupParameterAllowedValue>
{
    public StartupParameterAllowedValue Handler(GameStartupParameterAllowedValueResponse data, ICoreMap alsoMap)
        => new(data.Value, data.Label);
}
