using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record StatusResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("server")]
    public StatusServerResponse? Server { get; set; }

    [JsonPropertyName("game_info")]
    public StatusGameInfoResponse GameInfo { get; set; } = default!;

    [JsonPropertyName("config_file")]
    public string? ConfigFile { get; set; }

    [JsonPropertyName("resources")]
    public StatusResourcesResponse? Resources { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
}