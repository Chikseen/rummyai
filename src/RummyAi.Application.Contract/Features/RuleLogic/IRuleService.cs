using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.RuleLogic;
public interface IRuleService
{
    Game ValidateTurn(GameId gameId, PlayerId playerId, Move move);
}