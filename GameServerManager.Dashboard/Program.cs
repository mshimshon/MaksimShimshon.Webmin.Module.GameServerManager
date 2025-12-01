using GameServerManager.Dashboard;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();
var baseAddress = builder.HostEnvironment.BaseAddress;

// Extract query param directly from BaseAddress
var uri = new Uri(baseAddress);
var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(baseAddress) });

await builder.Build().RunAsync();
