using GameServerManager.Engine.Presentation;
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
// TODO: USE PLUGIN DISCOVERY

//Plugin lifecyclePlugin = new Plugin();
//lifecyclePlugin.Initialize();
//lifecyclePlugin.ConfigureWebHost(builder.Host);
//lifecyclePlugin.RegisterServices(builder.Services);

//builder.Services.AddScoped<Plugin>();
//builder.Services.AddScoped<IPlugin<Plugin>>();
//builder.Services.AddScoped<IPluginMetadata<Plugin>>();

//builder.Services.AddLifecyclePresentation();

//builder.Services.AddCap(p =>
//{
//    p.UseInMemoryStorage();
//    p.UseDashboard();
//});




WebApplication? app = builder.Build();

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

app.Run();
