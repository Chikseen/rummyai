using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameStartService
{
    Game StartGame(GameId gameId);
}