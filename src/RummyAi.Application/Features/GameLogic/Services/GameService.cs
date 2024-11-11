using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.HubIntegrationLogic;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameService(
    IHubIntegrationService hubIntegrationService,
    IGameGetService gameGetService,
    IGameAddPlayerService gameAddPlayerService,
    IGameStartService gameStartService,
    IGameMoveService gameMoveService
    ) : IGameService
{
    public Game GetGame(GameId gameId)
    {
        Game game = gameGetService.GetGame(gameId);
        hubIntegrationService.SendNewGameStatusToGroup(game);
        return game;
    }

    public Game AddPlayer(GameId gameId, PlayerConnection playerConnection)
    {
        Game game = gameAddPlayerService.AddPlayer(gameId, playerConnection);
        hubIntegrationService.SendNewGameStatusToGroup(game);
        return game;
    }

    public Game StartGame(GameId gameId)
    {
        Game game = gameStartService.StartGame(gameId);
        hubIntegrationService.SendNewGameStatusToGroup(game);
        return game;
    }

    public MoveResult MakeMove(Move move)
    {
        MoveResult moveResult = gameMoveService.MakeMove(move);
        hubIntegrationService.SendNewGameStatusToGroup(moveResult.Game);
        return moveResult;
    }
}
