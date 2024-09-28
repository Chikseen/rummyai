using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameAddPlayerService(
    IGameStateService gameStateService
    ) : IGameAddPlayerService
{
    public Game AddPlayer(GameId gameId, PlayerId playerId)
    {
        Game game = gameStateService.GetGame(gameId);

        game.GameState = GameState.PlayerSearch;

        Player player = new(playerId, PlayerType.Human);

        game.Players.Add(player);

        return game;
    }
}
