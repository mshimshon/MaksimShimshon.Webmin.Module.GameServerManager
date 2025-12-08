using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class ValidationResponseToValidationEntity : ICoreMapHandler<GameStartupParameterValidationResponse, GameStartupParameterValidationEntity>
{
    public GameStartupParameterValidationEntity Handler(GameStartupParameterValidationResponse data, ICoreMap alsoMap)
        => new()
        {
            Max = data.Max,
            Min = data.Min,
            MaxLength = data.MaxLength,
            MinLength = data.MinLength,
            UnitPrefix = data.UnitPrefix,
            UnitSuffix = data.UnitSuffix, PatternValidation = data.Pattern,
            AllowedValues = data.AllowedValues != default ? alsoMap.MapEach(data.AllowedValues).To<StartupParameterAllowedValue>() : default
        };
}
