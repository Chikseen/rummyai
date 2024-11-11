using RummyAi.Domain.Features.DeckDto.Models;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;
using System.Text.Json;

namespace RummyAi.Domain.Features.GameDto.Models;

public class Game
{
    public GameId GameId { get; init; }
    public GameState GameState { get; set; }
    public Stack HiddenStack { get; set; }
    public List<Stack> OpenStack { get; set; }
    public int Turn { get; set; }
    public List<Player> Players { get; set; }
    public Player? CurrentPlayer { get; set; }
    public List<PlayerCards> PlayerCards { get; set; }
    public DateTime Created { get; set; }

    public Game()
    {
        GameId = Guid.NewGuid();
        GameState = GameState.Init;
        Turn = 0;
        Players = [];
        HiddenStack = new();
        OpenStack = new();
        PlayerCards = [];
        Created = DateTime.UtcNow;
    }

    public Game(GameId gameId)
    {
        GameId = gameId;
        GameState = GameState.Init;
        Turn = 0;
        Players = [];
        HiddenStack = new();
        OpenStack = new();
        PlayerCards = [];
        Created = DateTime.UtcNow;
    }

    public int GetNumberOfPlayers()
    {
        return Players.Count;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
