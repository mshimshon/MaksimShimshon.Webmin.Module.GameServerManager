namespace GameServerManager.Core.Shared.Exceptions;

public class WebServiceException : Exception
{
    public WebServiceException(string? message) : base(message)
    {
    }
}
