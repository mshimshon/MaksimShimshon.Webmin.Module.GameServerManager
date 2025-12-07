using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record StatusResourcesResponse
{
    [JsonPropertyName("cpu")]
    public StatusCpuResponse? Cpu { get; set; }

    [JsonPropertyName("memory")]
    public StatusMemoryResponse? Memory { get; set; }

    [JsonPropertyName("storage")]
    public StatusStorageResponse? Storage { get; set; }
}