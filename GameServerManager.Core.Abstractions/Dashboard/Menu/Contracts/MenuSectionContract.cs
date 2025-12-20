namespace GameServerManager.Core.Abstractions.Dashboard.Menu.Contracts;

public record MenuSectionContract
{
    public string SectionId { get; init; } = default!;
    public string SectionName { get; init; } = default!;

}
