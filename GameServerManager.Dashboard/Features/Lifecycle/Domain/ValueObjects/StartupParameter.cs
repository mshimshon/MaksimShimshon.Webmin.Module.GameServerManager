using GameServerManager.Dashboard.Features.Lifecycle.Domain.Enums;

namespace GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

public sealed record StartupParameter
{
    public string Key { get; }
    public StartupParameterType StartupParameterType { get; }
    public StartupParameter(string key, StartupParameterType startupParameterType)
    {
        Key = key;
        StartupParameterType = startupParameterType;
    }
}
