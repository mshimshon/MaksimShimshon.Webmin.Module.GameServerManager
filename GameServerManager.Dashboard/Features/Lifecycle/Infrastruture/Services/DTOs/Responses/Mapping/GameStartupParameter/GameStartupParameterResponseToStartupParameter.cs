using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class GameStartupParameterResponseToStartupParameter : ICoreMapHandler<GameStartupParameterResponse, StartupParameter>
{
    public StartupParameter Handler(GameStartupParameterResponse data, ICoreMap alsoMap)
        => new StartupParameter(data.Key, data.Type.ToLower() switch 
        { 
            "decimal" => StartupParameterType.Decimal,
            "bool" => StartupParameterType.Bool,
            "bytesize" => StartupParameterType.ByteSize,
            "list" => StartupParameterType.List,
            "string" => StartupParameterType.String,
            "void" => StartupParameterType.Void,
            _ => StartupParameterType.Int
        });
}
