using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.RuleLogic;

public interface IRuleService
{
    bool ValidateMove(Move move, Game game);
}