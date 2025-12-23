using GameServerManager.Plugin.Core.Messaging.EventSystem;
using MudBlazor;

namespace GameServerManager.Engine.Presentation;

[EventBusId("Engine.EvenBus.CrossCircuit.Test", IsCrossCircuitReceiver = true)]
public class MenuTestEvenBusCrossHandler : IEventBusHandler
{
    private readonly IDialogService _dialogService;

    public MenuTestEvenBusCrossHandler(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
    public async Task HandleAsync(IEventBusMessage evt)
    {
        await _dialogService.ShowAsync<DialogTest>(evt.GetData()!.GetDataAs<string>()!);
    }
}
