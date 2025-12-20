namespace GameServerManager.Core.Abstractions.Dashboard.Menu.Exceptions;

public class MenuItemTargetMissingException : Exception
{
    public MenuItemTargetMissingException() : base("OnClick or Href must be defined.")
    {
    }
}
