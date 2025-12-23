using GameServerManager.Plugin.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GameServerManager.Plugin.Dashboard;


public class PluginEntry : IPlugin<PluginEntry>
{
    public void Initialize()
    {

    }
    public void RegisterServices(IServiceCollection services)
    {

    }
    public void Disable()
    {

    }

    public void Enable()
    {
        var asm = Assembly.GetExecutingAssembly();

        string nugetId = asm.GetCustomAttribute<AssemblyMetadataAttribute>()?.Value!;

        string version = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? asm.GetName().Version?.ToString();

        string displayName = asm.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

        string author = asm.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;

        string company = asm.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;

        string license = asm.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == "License")?.Value;

        string copyright = asm.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        Console.WriteLine("======= ENABLED PLUGIN ======");
        Console.WriteLine($"Id: {nugetId}");
        Console.WriteLine($"Name: {displayName}");
        Console.WriteLine($"Version: {version}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Company: {company}");
        Console.WriteLine($"License: {license}");
        Console.WriteLine($"Copyright: {copyright}");
    }
}
