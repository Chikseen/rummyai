using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameMoveService
{
    Game MakeMove(Move move);
}