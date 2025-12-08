using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Mapping.GameStartupParameter;

public class RelatedToResponseToConstraintTypeEntity : ICoreMapHandler<GameStartupParameterRelatedToResponse, GameStartupParameterConstraintTypeEntity>
{
    public GameStartupParameterConstraintTypeEntity Handler(GameStartupParameterRelatedToResponse data, ICoreMap alsoMap)
        => new GameStartupParameterConstraintTypeEntity()
        {
             Constraint = data.Constraint.ToLower() switch
             {
                 "equals" =>  StartupParameterConstraintType.Equals,
                 "greaterthan" =>  StartupParameterConstraintType.GreaterThan,
                 "greaterthanorequal" =>  StartupParameterConstraintType.GreaterThanOrEqual,
                 "lessthan" =>  StartupParameterConstraintType.LessThan,
                 "lessthanorequal" =>  StartupParameterConstraintType.LessThanOrEqual,
                 _ => StartupParameterConstraintType.NotEquals
             }, 
            Key = data.Key, 
            Message = data.Key
        };
}
