namespace GameServerManager.Core.Abstractions.Plugin.Contracts;

public record DependentAssemblyContract
{
    public Version? Min { get; init; }
    public Version? Max { get; init; }
    public string AssemblyName { get; init; } = default!;
    public DependentAssemblyContract(string assemblyName)
    {
        AssemblyName = assemblyName;
    }
}
