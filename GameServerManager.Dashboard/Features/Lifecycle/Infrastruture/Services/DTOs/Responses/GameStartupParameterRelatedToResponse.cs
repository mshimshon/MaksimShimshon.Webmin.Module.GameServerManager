using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterRelatedToResponse
{
    public string Key { get; init; } = default!;
    public string Constraint { get; init; } = default!;
    public string Message { get; init; } = default!;
}
