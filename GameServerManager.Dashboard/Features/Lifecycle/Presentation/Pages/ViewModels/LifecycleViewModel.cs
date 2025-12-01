namespace GameServerManager.Dashboard.Features.Lifecycle.Presentation.Pages.ViewModels;

public class LifecycleViewModel
{
    public bool IsRunning { get; set; }

    public Task Start()
    {
        if(IsRunning) return Task.CompletedTask;
        return Task.CompletedTask;
    }

    public Task Stop()
    {
        if (!IsRunning) return Task.CompletedTask;
            return Task.CompletedTask;
    }   

}
