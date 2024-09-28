using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameStateService : IGameStateService
{
    private Dictionary<Guid, Game> Games { get; set; } = [];

    public Game GetGame(GameId gameId)
    {
        try
        {
            return Games[(Guid)gameId.Id!];
        }
        catch (Exception)
        {
            throw new KeyNotFoundException($"Game with Id \"{gameId}\" not found");
        }
    }

    public Game GetGame(int postion)
    {
        try
        {
            return Games.ElementAt(postion).Value;
        }
        catch (Exception)
        {
            throw new DirectoryNotFoundException($"Game at Position \"{postion}\" not found");
        }
    }

    public void AddGame(Game game)
    {
        try
        {
            Games.Add((Guid)game.GameId.Id!, game);
        }
        catch (Exception)
        {
            throw new Exception($"Game with Id \"{game.GameId}\" allready exists");
        }
    }

    public Game InitGame(GameId gameId)
    {
        if (gameId.Id is null)
            gameId = new(Guid.NewGuid());

        Game game = new((Guid)gameId.Id!);

        Games.Add((Guid)game.GameId.Id!, game);

        return game;
    }

    public int GetNumberOfGames() => Games.Count;

    public bool Exists(GameId gameId) => Games.ContainsKey((Guid)gameId.Id!);
}
