using System.Text.Json.Serialization;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record StatusCpuResponse
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = default!;

    [JsonPropertyName("cores")]
    public int Cores { get; set; }

    [JsonPropertyName("usage")]
    public int Usage { get; set; }
}


