using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record StatusGameInfoResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("steam")]
    public bool Steam { get; set; }

    [JsonPropertyName("steam_app_id")]
    public string? SteamAppId { get; set; }

    [JsonPropertyName("modding")]
    public bool Modding { get; set; }

    [JsonPropertyName("workshop")]
    public bool Workshop { get; set; }

    [JsonPropertyName("manual_mod_upload")]
    public bool ManualModUpload { get; set; }
}
