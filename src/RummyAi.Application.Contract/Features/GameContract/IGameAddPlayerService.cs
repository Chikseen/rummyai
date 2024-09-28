using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameAddPlayerService
{
    Game AddPlayer(GameId gameId, PlayerId playerId);
}