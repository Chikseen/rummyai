using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;

public interface IGameService
{
    Game GetGame(GameId gameId);
    Game AddPlayer(GameId gameId, PlayerId playerId);
    Game StartGame(GameId gameId);
}