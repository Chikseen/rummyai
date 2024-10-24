using Microsoft.AspNetCore.SignalR;
using RummyAi.Application.Contract.Features.HubIntegrationLogic;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Model;
using RummyAi.Domain.Hubs;

namespace RummyAi.Application.Features.HubIntegrationLogic;

public class HubIntegrationService(
    IHubContext<GameHub> hubContext
    ) : IHubIntegrationService
{
    public void AddPlayerToGroup(Game game, PlayerConnection playerConnection)
    {
        string conenctionId = playerConnection.ConenctionId;
        string gameIdString = game.GameId.Id.ToString()!;

        hubContext.Groups.AddToGroupAsync(conenctionId, gameIdString);
    }

    public void SendNewGameStatusToGroup(Game game)
    {
        string gameIdString = game.GameId.Id.ToString()!;

        hubContext.Clients.Groups(gameIdString).SendAsync(HubConnectionsNames.NewGameState, game);
    }
}
