using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;
using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;

public record GameInfoResponse
{
    public string Name { get; set; } = default!;
    public bool Steam { get; set; }

    [JsonPropertyName("steam_app_id")]
    public string? SteamAppId { get; set; }
    public bool Modding { get; set; }
    public bool Workshop { get; set; }

    [JsonPropertyName("manual_mod_upload")]
    public bool ManualModUpload { get; set; }
    public List<GameStartupParameterResponse> Parameters { get; init; } = new();

}
