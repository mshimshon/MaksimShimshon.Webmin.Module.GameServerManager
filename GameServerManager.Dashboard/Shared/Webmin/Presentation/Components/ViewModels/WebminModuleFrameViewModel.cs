using Blazored.LocalStorage;
using Microsoft.JSInterop;
using SwizzleV;

namespace GameServerManager.Dashboard.Shared.Webmin.Presentation.Components.ViewModels;

public class WebminModuleFrameViewModel
{
    public string ModuleName { get; set; } = default!;
    public string Source { get; private set; } = default!;
    private string? _pastQuery = default;
    private bool _loading = false;
    public bool Loading
    {
        get => _loading;
        set
        {
            if (value != _loading)
                _ = _swizzleViewModel.SpreadChanges(() => this);
            _loading = value;
        }
    }


    private readonly ISwizzleViewModel _swizzleViewModel;
    private readonly IJSRuntime _js;
    private readonly ILocalStorageService _localStorageService;

    public WebminModuleFrameViewModel(ISwizzleViewModel swizzleViewModel, IJSRuntime js, ILocalStorageService localStorageService)
    {
        _swizzleViewModel = swizzleViewModel;
        _js = js;
        _localStorageService = localStorageService;
    }

    public async Task LoadAsync()
    {
        Loading = true;
        await RestoreURLState();
        Source = $"/{ModuleName}/index.cgi{_pastQuery}";
        Loading = false;
    }

    public async Task UnloadAsync()
    {
        await SaveURLState();
    }

    private async Task SaveURLState()
    {
        var queryString = await _js.InvokeAsync<string>("eval",  "document.getElementById('myIframe').contentWindow.location.search");
        if (string.IsNullOrEmpty(queryString)) return;
        await _localStorageService.SetItemAsStringAsync($"{ModuleName}_Query", queryString);
    }

    private async Task RestoreURLState()
    {
        _pastQuery = await _localStorageService.GetItemAsStringAsync($"{ModuleName}_Query");
    }


}
