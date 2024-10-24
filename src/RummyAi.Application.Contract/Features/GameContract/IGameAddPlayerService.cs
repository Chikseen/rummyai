using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameAddPlayerService
{
    Game AddPlayer(GameId gameId, PlayerConnection playerConnection);
}