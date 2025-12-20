namespace GameServerManager.Core.Shared.Webmin.Infrastruture.Exceptions;

public class WebminLoginExpiredException : Exception
{
    public WebminLoginExpiredException(string? message) : base(message)
    {
    }
}
