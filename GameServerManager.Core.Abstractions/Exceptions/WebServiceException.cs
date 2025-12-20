namespace GameServerManager.Core.Abstractions.Exceptions;

public class WebServiceException : Exception
{
    public WebServiceException(string? message) : base(message)
    {
    }
}
