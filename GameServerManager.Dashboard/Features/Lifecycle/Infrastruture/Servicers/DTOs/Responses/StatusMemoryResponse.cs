using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record StatusMemoryResponse
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("used")]
    public int Used { get; set; }

    [JsonPropertyName("free")]
    public int Free { get; set; }
}
