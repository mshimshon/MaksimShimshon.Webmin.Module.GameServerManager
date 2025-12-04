using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record StatusStorageResponse
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("used")]
    public int Used { get; set; }

    [JsonPropertyName("available")]
    public int Available { get; set; }
}

