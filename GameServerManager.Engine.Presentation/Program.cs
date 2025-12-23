using GameServerManager.Engine.Presentation;
using GameServerManager.Engine.Presentation.Services.Messaging.EngineBus;
using GameServerManager.Engine.Presentation.Services.Messaging.EventBus;
using GameServerManager.Engine.Presentation.Services.Messaging.QueryBus;
using GameServerManager.Plugin.Core;
using GameServerManager.Plugin.Dashboard;
using MudBlazor;
using MudBlazor.Services;
using StatePulse.Net;
using SwizzleV;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// TODO: USE PLUGIN DISCOVERY
//builder.Services.AddCoreServices([
//    typeof(Program),
//     typeof(GameServerManager.Core._Imports),
//     typeof(GameServerManager.Features.Lifecycle._Imports)
//    ]);

builder.Services.AddEnginePresentation();
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
    o.ScanAssemblies = [
            typeof(Program),
            typeof(GameServerManager.Engine.Application.RegisterServicesExt),
            typeof(GameServerManager.Engine.Infrastructure.RegisterServicesExt)
        ];
});


builder.Services.AddSwizzleV();

builder.Services.ScanEngineBusHandlers([typeof(Program).Assembly, typeof(PluginEntry).Assembly]);
builder.Services.ScanEventBusHandlers([typeof(Program).Assembly, typeof(PluginEntry).Assembly]);
builder.Services.ScanQueryBusHandlers([typeof(Program).Assembly, typeof(PluginEntry).Assembly]);
// TODO: USE PLUGIN DISCOVERY

IPlugin<PluginEntry> pluginDashboard = new PluginEntry();
pluginDashboard.Enable();
pluginDashboard.Initialize();
pluginDashboard.RegisterServices(builder.Services);

builder.Services.AddScoped<PluginEntry>();
builder.Services.AddScoped<IPlugin<PluginEntry>, PluginEntry>();


//builder.Services.AddCap(p =>
//{
//    p.UseInMemoryStorage();
//    p.UseDashboard();
//});




WebApplication? app = builder.Build();

app.RegisterScannedEngineBusHandlers();
app.RegisterScannedEventBusHandlers();
app.RegisterScannedQueryBusHandlers();

// TODO: USE PLUGIN DISCOVERY

//lifecyclePlugin.ConfigureWebBuilder(app);
//lifecyclePlugin.ConfigureEndpoints(app);
//lifecyclePlugin.ThisIsHost(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//app.StartTicker(new TimeOnly(0, 0, 1));

await app.RunAsync();
