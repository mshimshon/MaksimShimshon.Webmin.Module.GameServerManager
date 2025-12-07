using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterAllowedValueResponse
{
    [JsonPropertyName("value")]
    public string Value { get; init; } = default!;

    [JsonPropertyName("label")]
    public string Label { get; init; } = default!;
}
