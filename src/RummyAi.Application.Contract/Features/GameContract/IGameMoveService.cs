using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameMoveService
{
    MoveResult MakeMove(Move move);
}