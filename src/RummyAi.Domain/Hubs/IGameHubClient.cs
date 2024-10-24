using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Domain.Hubs;

public interface IGameHubClient
{
    Task JoinGame(GameId gameId);
    Task SendNewGameStateToGameId(Game game);
}