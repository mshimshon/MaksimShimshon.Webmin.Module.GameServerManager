using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses;
/*
 {
  "status": "STOPPED",
  "server": {
    "name": "LinuxGSM",
    "ip": "0.0.0.0",
    "port": 16261,
    "max_players": 16
  },
  "config_file": "/home/lgsm/Zomboid/Server/pzserver.ini",
  "resources": {
    "cpu": {
      "model": "Intel(R) Xeon(R) CPU E5-2680 v4 @ 2.40GHz",
      "cores": 4,
      "usage": 0
    },
    "memory": {
      "total": 4096,
      "used": 296,
      "free": 3788
    },
    "storage": {
      "total": 24576,
      "used": 3584,
      "available": 21504
    }
  },
  "timestamp": "2025-12-05T14:59:05Z"
}
 */
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