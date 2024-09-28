using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Contract.Features.GameContract;
public interface IGameStateService
{
    void AddGame(Game game);
    Game GetGame(GameId gameId);
    Game GetGame(int postion);
    Game InitGame(GameId gameId);
    int GetNumberOfGames();
    bool Exists(GameId gameId);
}