namespace GameServerManager.Skeleton.Bootstraper.Exceptions;

public class DuplicatePluginException : Exception
{
    public DuplicatePluginException() : base("Plugin cannot be registered more than once.")
    {
    }
}
