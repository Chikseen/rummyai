using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.RuleLogic;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameMoveService(
    IGameStateService gameStateService,
    IRuleService ruleService
    ) : IGameMoveService
{
    public Game MakeMove(Move move)
    {
        Game game = gameStateService.GetGame(move.GameId);
        if (!(game.GameState == GameState.WaitingForMove))
            throw new Exception("Game has not started yet");

        bool isMoveValid = ruleService.ValidateMove(move, game);

        if (isMoveValid)
        {
            SetNextPlayer(game);
        }

        return game;
    }

    private void SetNextPlayer(Game game)
    {
        game.Turn++;
        int numberOfPlayers = game.GetNumberOfPlayers();
        int turns = game.Turn;

        int currentPlayer = turns % numberOfPlayers;

        game.CurrentPlayer = game.Players[currentPlayer];
    }
}
