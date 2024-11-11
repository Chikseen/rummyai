using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Contract.Features.GameContract;

public interface IGameService
{
    Game GetGame(GameId gameId);
    Game AddPlayer(GameId gameId, PlayerConnection playerConnection);
    Game StartGame(GameId gameId);
    MoveResult MakeMove(Move move);
}