using GameServerManager.Core.Abstractions.Dashboard.Menu.Exceptions;

namespace GameServerManager.Core.Abstractions.Dashboard.Menu.Contracts;

public record MenuContract 
{
    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Href { get; init; }
    public Func<Task>? OnClick { get; init; }
    public Func<bool>? VisibleCondition { get; init; }
    public bool IsVisible => VisibleCondition?.Invoke() ?? true;

    public Func<bool>? Disabled { get; init; }
    public bool IsDisabled => Disabled?.Invoke() ?? false;

    public string SectionId { get; init; } = default!; 
    public string? AfterId { get; init; }
    public string? BeforeId { get; init; }

    public MenuContract(string href)
    {
        if (string.IsNullOrWhiteSpace(href)) throw new MenuItemTargetMissingException();
        Href = href;
    }
    public MenuContract(Func<Task> onClick)
    {
        if (onClick == default) throw new MenuItemTargetMissingException();
        OnClick = onClick;
    }
}
