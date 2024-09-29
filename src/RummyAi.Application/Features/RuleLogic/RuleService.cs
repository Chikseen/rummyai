using RummyAi.Application.Contract.Features.RuleLogic;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Features.RuleLogic;

public class RuleService : IRuleService
{
    public Game ValidateTurn(GameId gameId, PlayerId playerId, Move move)
    {
        return new();
    }
}
