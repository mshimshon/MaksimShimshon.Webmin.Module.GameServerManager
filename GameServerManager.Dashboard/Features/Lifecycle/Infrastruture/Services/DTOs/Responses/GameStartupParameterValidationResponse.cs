using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterValidationResponse
{
    [JsonPropertyName("min")]
    public int? Min { get; init; }

    [JsonPropertyName("max")]
    public int? Max { get; init; }

    [JsonPropertyName("minLength")]
    public int? MinLength { get; init; }

    [JsonPropertyName("maxLength")]
    public int? MaxLength { get; init; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; init; }

    [JsonPropertyName("allowedValues")]
    public List<GameStartupParameterAllowedValueResponse>? AllowedValues { get; init; }

    [JsonPropertyName("unit")]
    public string? Unit { get; init; }
}
