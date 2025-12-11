using GameServerManager.Dashboard.Shared.Providers.Infrastructure.Services;
using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterResponse
{
    public string Key { get; init; } = default!;
    public string Type { get; init; } = default!;
    public string Label { get; init; } = default!;
    public string Description { get; init; } = default!;
    public bool Required { get; init; }
    public bool Editable { get; init; }

    [JsonConverter(typeof(JsonAlwaysStringConverter))]
    public string? DefaultValue { get; init; }
    public GameStartupParameterValidationResponse? Validation { get; init; }
    public GameStartupParameterRelatedToResponse? RelatedTo { get; init; }
    public string Category { get; init; } = default!;
    public string? Warning { get; init; }
}
