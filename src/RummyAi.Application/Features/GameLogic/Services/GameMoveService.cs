using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.HubIntegrationLogic;
using RummyAi.Application.Contract.Features.RuleLogic;
using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.DeckDto.Models;
using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.GameDto.Enum;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Features.GameLogic.Services;

public class GameMoveService(
    IHubIntegrationService hubIntegrationService,
    IGameStateService gameStateService,
    IRuleService ruleService
    ) : IGameMoveService
{
    public MoveResult MakeMove(Move move)
    {
        Game game = gameStateService.GetGame(move.GameId);
        if (!(game.GameState == GameState.WaitingForMove))
            throw new Exception("Game has not started yet");

        bool isMoveValid = ruleService.ValidateMove(move, game);

        if (isMoveValid)
        {
            PlayerCards playersStack = game.PlayerCards.Find(playerStack => playerStack.PlayerId == move.PlayerId.Id)!;

            List<Card> reducedStack = playersStack.Stack.Cards
                .Where(playerCard => move.Stack.Cards
                    .All(card => card != playerCard))
                .ToList();

            List<Card> playedStack = move.Stack.Cards;

            game.OpenStack.Add(new Stack(playedStack));
            game.PlayerCards.Find(playerStack => playerStack.PlayerId == move.PlayerId.Id)!.Stack.Cards = reducedStack;


            SetNextPlayer(game);
        }

        MoveResult moveResult = new(game, move, isMoveValid);

        return moveResult;
    }

    private void SetNextPlayer(Game game)
    {
        int numberOfPlayers = game.GetNumberOfPlayers();
        int turns = game.Turn;
        game.Turn++;

        int currentPlayer = turns % numberOfPlayers;

        game.CurrentPlayer = game.Players[currentPlayer];

        if (game.CurrentPlayer.PlayerType == PlayerType.Ai)
        {
            Task.Run(() => MakeAiMove(game));
        }
    }

    // ONLY FOR DEBUGGING
    private void MakeAiMove(Game game)
    {
        Thread.Sleep(2500);

        // Use Hardcoded now
        // Use Random later
        // Use AiModel super later
        PlayerId currentPlayerId = game.CurrentPlayer.PlayerId;

        List<Card> currentPlayerStack = game.PlayerCards
            .Find(player => player.PlayerId == currentPlayerId)!
            .Stack.Cards;

        Card firstPlayerCard = currentPlayerStack.First();

        List<Card> cardSuitableForMove = currentPlayerStack.Where(card => card.Suit == firstPlayerCard.Suit).ToList();

        Move aiMove = new()
        {
            GameId = game.GameId,
            PlayerId = game.CurrentPlayer.PlayerId,


            Stack = new()
            {
                Cards = cardSuitableForMove
            }
        };

        MakeMove(aiMove);

        hubIntegrationService.SendNewGameStatusToGroup(game);
    }
    // ONLY FOR DEBUGGING
}
