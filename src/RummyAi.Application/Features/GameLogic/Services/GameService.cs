﻿using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameService(
    IGameGetService gameGetService,
    IGameAddPlayerService gameAddPlayerService,
    IGameStartService gameStartService,
    IGameMoveService gameMoveService
    ) : IGameService
{
    public Game GetGame(GameId gameId)
        => gameGetService.GetGame(gameId);

    public Game AddPlayer(GameId gameId, PlayerId playerId)
        => gameAddPlayerService.AddPlayer(gameId, playerId);

    public Game StartGame(GameId gameId)
        => gameStartService.StartGame(gameId);

    public Game MakeMove(Move move)
        => gameMoveService.MakeMove(move);
}
