namespace GameServerManager.Dashboard.Shared.Exceptions;

public class WebServiceException : Exception
{
    public WebServiceException(string? message) : base(message)
    {
    }
}
