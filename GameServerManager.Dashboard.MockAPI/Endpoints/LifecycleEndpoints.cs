namespace GameServerManager.Dashboard.MockAPI.Endpoints;

public static class LifecycleEndpoints
{
    public static void MapServerEndpoints(this WebApplication app)
    {
        app.MapGet("/blazor_lgsm/script/server/status.cgi", async () => await DataReader.ReturnJsonFile("server.json"));

    }
}
