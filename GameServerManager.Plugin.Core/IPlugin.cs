using Microsoft.Extensions.DependencyInjection;

namespace GameServerManager.Plugin.Core;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar", "S2326")]
public interface IPlugin<TEntry>
    where TEntry : class
{
    void Initialize();
    void RegisterServices(IServiceCollection services);
    void Disable();
    void Enable();
}
