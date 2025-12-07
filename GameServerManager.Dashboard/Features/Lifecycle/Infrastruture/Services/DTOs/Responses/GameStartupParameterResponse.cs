using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Enum;
using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterResponse
{
    [JsonPropertyName("key")]
    public string Key { get; init; } = default!;

    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public GameStartupParameterTypeResponse Type { get; init; }

    [JsonPropertyName("label")]
    public string Label { get; init; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("editable")]
    public bool Editable { get; init; }

    [JsonPropertyName("defaultValue")]
    public object? DefaultValue { get; init; }

    [JsonPropertyName("validation")]
    public GameStartupParameterValidationResponse? Validation { get; init; }

    [JsonPropertyName("relatedTo")]
    public GameStartupParameterRelatedToResponse? RelatedTo { get; init; }

    [JsonPropertyName("category")]
    public string? Category { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("warning")]
    public string? Warning { get; init; }
}
