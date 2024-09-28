using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameGetService
{
    Game GetGame(GameId gameId);
}