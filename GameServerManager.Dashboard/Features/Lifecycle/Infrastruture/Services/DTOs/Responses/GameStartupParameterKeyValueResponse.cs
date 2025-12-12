namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses;

public record GameStartupParameterKeyValueResponse
{
    public string Key { get; set; }
    public string Value { get; set; }
}
