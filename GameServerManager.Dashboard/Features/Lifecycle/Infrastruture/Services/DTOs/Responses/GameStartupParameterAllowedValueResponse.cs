using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterAllowedValueResponse
{
    public string Value { get; init; } = default!;
    public string Label { get; init; } = default!;
}
