namespace GameServerManager.Dashboard.MockAPI;

public static class DataReader
{
    public static async Task<IResult> ReturnJsonFile(string filename)
    {
        var path = Path.Combine("MockData", filename);

        if (!File.Exists(path))
            return Results.NotFound(new { error = $"File not found: {filename}" });

        var json = await File.ReadAllTextAsync(path);
        return Results.Content(json, "application/json");
    }
}
