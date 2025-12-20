using System.Text.Json.Serialization;

namespace GameServerManager.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record StatusServerResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("ip")]
    public string Ip { get; set; } = default!;

    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("max_players")]
    public int MaxPlayers { get; set; }
}
