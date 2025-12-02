using Blazored.LocalStorage;
using GameServerManager.Dashboard;
using GameServerManager.Dashboard.Features.Lifecycle.Presentation;
using GameServerManager.Dashboard.Shared.Webmin.Presentation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;
using StatePulse.Net;
using SwizzleV;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();
builder.Services.AddStatePulseServices(o =>
{
    o.ScanAssemblies = new Type[] { typeof(Program) };
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
await builder.Build().RunAsync();
