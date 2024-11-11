using Microsoft.Extensions.Options;
using RummyAi.Application.Contract.Features.BoardContract;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features;
using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.DeckDto.Models;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameStartService(
    IOptions<ConfigurationOptions> options,
    IGenerateDeckService generateDeckService,
    IGameGetService gameGetService
    ) : IGameStartService
{
    public Game StartGame(GameId gameId)
    {
        Game game = gameGetService.GetGame(gameId);

        game.Players.AddRange(AddMissingPlayer(game));
        game.HiddenStack = AssginRandomStack();
        game.PlayerCards = AssignCardsToPlayers(game);

        game.GameState = GameState.WaitingForMove;

        game.Turn = 1;
        game.CurrentPlayer = game.Players.First();

        return game;
    }

    private List<Player> AddMissingPlayer(Game game)
    {
        int numberOfCurrentPlayer = game.Players.Count;
        int minimumNumberOfPlayer = 2;

        int missingPlayer = minimumNumberOfPlayer - numberOfCurrentPlayer;

        List<Player> players = [];

        for (int i = 0; i < missingPlayer; i++)
            players.Add(new(
                Guid.NewGuid(),
                PlayerType.Ai));

        return players;
    }

    private List<PlayerCards> AssignCardsToPlayers(Game game)
    {
        int amountOfCardsPerPlayer = options.Value.InitNumberOfCardsPerPlayer;

        bool deckHasEnoughCards = CheckDeckHasEnoughCards(game);
        if (!deckHasEnoughCards)
            throw new Exception("Not enough cards in the deck to start the game");

        List<PlayerCards> players = [];

        foreach (Player player in game.Players)
        {
            PlayerId playerId = player.PlayerId;

            List<Card> cards = game.HiddenStack.Cards.Take(amountOfCardsPerPlayer).ToList();
            game.HiddenStack.Cards.RemoveRange(0, amountOfCardsPerPlayer);
            Stack stack = new(cards);

            players.Add(new(playerId, stack));
        }

        return players;
    }

    private bool CheckDeckHasEnoughCards(Game game)
    {
        int amountOfCardsPerPlayer = options.Value.InitNumberOfCardsPerPlayer;
        int totalCardsNeeded = game.Players.Count * amountOfCardsPerPlayer;
        int differeneceInCards = game.HiddenStack.Cards.Count - totalCardsNeeded;

        return differeneceInCards > 0;
    }

    private Stack AssginRandomStack()
        => generateDeckService.GenerateRandom();
}
