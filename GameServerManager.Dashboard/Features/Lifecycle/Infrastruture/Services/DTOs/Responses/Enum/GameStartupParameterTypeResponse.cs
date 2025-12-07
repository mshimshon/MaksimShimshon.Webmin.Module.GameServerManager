using System.Text.Json.Serialization;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Services.DTOs.Responses.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameStartupParameterTypeResponse
{
    [JsonPropertyName("string")]
    String,

    [JsonPropertyName("bool")]
    Bool,

    [JsonPropertyName("list")]
    List,

    [JsonPropertyName("number")]
    Number,

    [JsonPropertyName("void")]
    Void,

    [JsonPropertyName("byteSize")]
    ByteSize
}
