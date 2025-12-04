using Blazored.LocalStorage;
using GameServerManager.Dashboard;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation;
using GameServerManager.Dashboard.Shared.Providers.Presentation;
using GameServerManager.Dashboard.Shared.Webmin.Presentation;
using MedihatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;
using StatePulse.Net;
using SwizzleV;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddStatePulseServices(o =>
{
    o.ScanAssemblies = new Type[] { typeof(Program) };
});
builder.Services.AddMedihaterServices(cfg =>
{
    cfg.AssembliesScan = [
        typeof(Program)
    ];
});
builder.Services.AddSwizzleV();
builder.Services.AddBlazoredLocalStorageAsSingleton();
var baseAddress = builder.HostEnvironment.BaseAddress;

// Extract query param directly from BaseAddress
var uri = new Uri(baseAddress);
var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(baseAddress) });
builder.Services.AddWebminPresentation();
builder.Services.AddLifecyclePresentation();
builder.Services.AddProviderPresentation();
await builder.Build().RunAsync();
