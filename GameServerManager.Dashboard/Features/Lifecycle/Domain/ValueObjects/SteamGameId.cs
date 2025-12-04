namespace GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

public record SteamGameId
{
    public SteamGameId(string steamid, bool hasModdingWorkshop)
    {
        Steamid = steamid;
        HasModdingWorkshop = hasModdingWorkshop;
    }

    public string Steamid { get; }
    public bool HasModdingWorkshop { get; }
}
