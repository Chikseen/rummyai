using Microsoft.AspNetCore.SignalR;
using RummyAi.Domain.Features.GameDto;

namespace RummyAi.Domain.Hubs;

public class GameHub : Hub<IGameHubClient>
{
    public Task JoinGame(GameId gameId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, gameId.Id.ToString());
    }
}
