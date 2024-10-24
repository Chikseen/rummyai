namespace RummyAi.Domain.Hubs;

public static class HubConnectionsNames
{
    public static string NewGameState = nameof(IGameHubClient.SendNewGameStateToGameId);
}
