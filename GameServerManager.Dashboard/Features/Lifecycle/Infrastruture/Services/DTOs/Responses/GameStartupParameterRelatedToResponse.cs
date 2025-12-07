using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Enum;
using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterRelatedToResponse
{
    [JsonPropertyName("parameter")]
    public string Parameter { get; init; } = default!;

    [JsonPropertyName("constraint")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public GameStartupParameterConstraintTypeResponse Constraint { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; } = default!;
}
