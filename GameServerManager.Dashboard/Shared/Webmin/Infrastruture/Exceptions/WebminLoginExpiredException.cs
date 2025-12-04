namespace GameServerManager.Dashboard.Shared.Webmin.Infrastruture.Exceptions;

public class WebminLoginExpiredException : Exception
{
    public WebminLoginExpiredException(string? message) : base(message)
    {
    }
}
