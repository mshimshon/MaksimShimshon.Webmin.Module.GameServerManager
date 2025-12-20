using System.Text.Json.Serialization;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record StatusResourcesResponse
{
    [JsonPropertyName("cpu")]
    public StatusCpuResponse? Cpu { get; set; }

    [JsonPropertyName("memory")]
    public StatusMemoryResponse? Memory { get; set; }

    [JsonPropertyName("storage")]
    public StatusStorageResponse? Storage { get; set; }
}