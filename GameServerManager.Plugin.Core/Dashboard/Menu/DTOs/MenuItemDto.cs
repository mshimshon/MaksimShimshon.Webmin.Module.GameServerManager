namespace GameServerManager.Plugin.Core.Dashboard.Menu.DTOs;

public record MenuItemDto
{
    public string Title { get; init; } = default!;
    public string Icon { get; init; } = "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M19 19H5V5h7V3H5c-1.11 0-2 .9-2 2v14c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2v-7h-2v7zM14 3v2h3.59l-9.83 9.83 1.41 1.41L19 6.41V10h2V3h-7z\"/>";
    public string? Target { get; init; }
    public string? Link { get; }
    public Func<Task>? Onclick { get; }

    public MenuItemDto(string link)
    {
        Link = link;
    }
    public MenuItemDto(Func<Task> onclick)
    {
        Onclick = onclick;
    }
}
