using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class GameStartupParameterResponseToGameStartupParameterEntity : ICoreMapHandler<GameStartupParameterResponse, GameStartupParameterEntity>
{
    public GameStartupParameterEntity Handler(GameStartupParameterResponse data, ICoreMap alsoMap)
        => new()
        {
            Category = data.Category,
            DefaultValue = data.DefaultValue,
            Description = data.Description,
            Editable = data.Editable,
            Label = data.Label,
            Required = data.Required,
            Warning = data.Warning, 
            RelatedTo = data.RelatedTo != default ? alsoMap.Map(data.RelatedTo).To<GameStartupParameterConstraintTypeEntity>() : default,
            Validation = data.Validation != default ? alsoMap.Map(data.Validation).To<GameStartupParameterValidationEntity>() : default,
            Key = alsoMap.Map(data).To<StartupParameter>()
        };
}
