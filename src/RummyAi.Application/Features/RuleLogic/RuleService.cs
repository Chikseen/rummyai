using RummyAi.Application.Contract.Features.RuleLogic;
using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.CardDto.Models;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.MachineLearning;
using System.Text.Json;

namespace RummyAi.Application.Features.RuleLogic;

public class RuleService() : IRuleService
{
    public bool ValidateMove(Move move, Game game)
    {
        ValidateMetaData(move, game);

        // Super Simple Ruleset to create data for first AiModel
        bool isSuitValid = ValidateSameSuit(move, game);

        StoreInCsvFile(move.Stack.Cards, isSuitValid);

        return isSuitValid;
    }

    private void ValidateMetaData(Move move, Game game)
    {
        // Check later if correct Player, Game usw
    }

    private bool ValidateSameSuit(Move move, Game game)
    {
        List<IGrouping<Suits, Card>> sortedCards = move.Stack.Cards
            .GroupBy(c => c.Suit)
            .ToList();

        if (sortedCards.Count() == 1)
            return true;
        return false;
    }

    private void StoreInCsvFile(List<Card> cards, bool isSuitValid)
    {
        MoveData moveIo = new()
        {
            IsMoveValid = isSuitValid ? 1.0f : 0.0f,
            Cards = cards
        };

        if (!File.Exists("I:/_User/Desktop/test.json"))
            File.WriteAllText("I:/_User/Desktop/test.json", "[]");

        string inputText = File.ReadAllText("I:/_User/Desktop/test.json");
        List<MoveData> moveIos = JsonSerializer.Deserialize<List<MoveData>>(inputText)!;
        moveIos.Add(moveIo);
        string outputText = JsonSerializer.Serialize(moveIos);
        File.WriteAllText("I:/_User/Desktop/test.json", outputText);
    }
}
