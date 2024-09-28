using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.RandomContract;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameGetService(
    IRandomService randomService,
    IGameStateService gameStateService
    ) : IGameGetService
{
    public Game GetGame(GameId gameId)
    {
        if (gameId?.Id is null)
        {
            int allGames = gameStateService.GetNumberOfGames();
            if (allGames == 0)
                return gameStateService.InitGame(gameId!);

            int randomGameNumber = randomService.GetRandomRange(0, allGames);

            Game randomGame = gameStateService.GetGame(randomGameNumber);

            return randomGame;
        }

        bool gameExists = gameStateService.Exists(gameId!);

        if (gameExists)
            return gameStateService.GetGame(gameId);

        Game game = gameStateService.InitGame(gameId);
        return game;
    }
}
