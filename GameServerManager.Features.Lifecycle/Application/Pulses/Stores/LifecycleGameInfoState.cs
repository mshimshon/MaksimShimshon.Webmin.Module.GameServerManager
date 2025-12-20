using GameServerManager.Features.Lifecycle.Domain.Entites;
using StatePulse.Net;

namespace GameServerManager.Features.Lifecycle.Application.Pulses.Stores;

public record LifecycleGameInfoState : IStateFeature
{
    public GameInfoEntity? GameInfo { get; init; }
    public Dictionary<string, string> StartupParameters { get; init; } = new();
    public bool SavedParametersLoaded { get; init; }
}
