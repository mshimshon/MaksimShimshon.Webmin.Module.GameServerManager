using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameStartupParameterConstraintTypeResponse
{
    [JsonPropertyName("lessThan")]
    LessThan,

    [JsonPropertyName("lessThanOrEqual")]
    LessThanOrEqual,

    [JsonPropertyName("greaterThan")]
    GreaterThan,

    [JsonPropertyName("greaterThanOrEqual")]
    GreaterThanOrEqual,

    [JsonPropertyName("equals")]
    Equals,

    [JsonPropertyName("notEquals")]
    NotEquals,

    [JsonPropertyName("shouldEqual")]
    ShouldEqual
}
