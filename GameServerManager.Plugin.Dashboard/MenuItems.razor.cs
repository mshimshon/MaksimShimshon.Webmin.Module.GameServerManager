using GameServerManager.Plugin.Core.Messaging.EngineBus;
using GameServerManager.Plugin.Core.Messaging.EventSystem;
using GameServerManager.Plugin.Core.Messaging.QuerySystem;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GameServerManager.Plugin.Dashboard;

public partial class MenuItems : ComponentBase
{
    [Inject] IEngineBus EngineBus { get; set; } = default!;
    [Inject] IQueryBus QueryBus { get; set; } = default!;
    [Inject] IEventBus EventBus { get; set; } = default!;
    [Inject] IDialogService DialogService { get; set; } = default!;
    ICollection<RenderFragment> Items { get; set; } = new List<RenderFragment>();
    public bool IsVisible { get; set; }
    public async Task GetPluginMenuItems()
    {
        var message = new EngineBusMessage("GameServerManager.Plugin.Dashboard.EngineBus", "FetchAdditionalMenu");
        var response = await EngineBus.ExecAsync(message);
        Items = response
            .Select(p => (p.RenderFragment))
            .ToList();

        await InvokeAsync(StateHasChanged);
    }

    public async Task GetBoolTest()
    {
        QueryBusMessageResponse? response = await QueryBus.QueryAsync(new QueryBusMessage("Engine.QueryBus", "Test"));
        IsVisible = response.Data!.GetDataAs<bool>()!;
        await InvokeAsync(StateHasChanged);
    }

    public async Task SendEventCrossCircuit()
    {
        await EventBus.PublishAsync(new EventBusMessage("Engine.EvenBus.CrossCircuit", "Test", "This is my event cross-cricuit mofo"));
    }
}
