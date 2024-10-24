using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.HubIntegrationLogic;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameAddPlayerService(
    IGameStateService gameStateService,
    IHubIntegrationService hubIntegrationService
    ) : IGameAddPlayerService
{
    public Game AddPlayer(GameId gameId, PlayerConnection playerConnection)
    {
        Game game = gameStateService.GetGame(gameId);

        game.GameState = GameState.PlayerSearch;

        Player player = new(playerConnection.PlayerId, PlayerType.Human);

        game.Players.Add(player);

        hubIntegrationService.AddPlayerToGroup(game, playerConnection);
        hubIntegrationService.SendNewGameStatusToGroup(game);

        return game;
    }
}
