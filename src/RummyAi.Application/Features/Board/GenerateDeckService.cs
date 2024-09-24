using Microsoft.Extensions.Options;
using RummyAi.Application.Contract.Features.Board;
using RummyAi.Application.Contract.Features.RandomProvider;
using RummyAi.Application.Extensions.StackProvider;
using RummyAi.Domain.Features;
using RummyAi.Domain.Features.Cards;
using RummyAi.Domain.Features.Deck;

namespace RummyAi.Application.Features.Board;

public class GenerateDeckService(
        IRandomService randomService,
        IOptions<ConfigurationOptions> options
    ) : IGenerateDeckService
{
    public Stack GenerateRandom()
    {
        Stack deck = GetDeck();

        deck.Shuffle(randomService.GetRandom());

        return deck;
    }

    public Stack GetDeck()
    {
        int ammountOfStacks = options.Value.AmmountOfStacks;

        List<Card> cards = GetSingleDeck(ammountOfStacks);

        Stack deck = new() { Cards = cards };

        return deck;
    }

    private List<Card> GetSingleDeck(int ammountOfStacks = 1)
    {
        int numberOfDefinedSuits = Enum.GetNames(typeof(Suits)).Length;
        int numberOfDefinedRanks = Enum.GetNames(typeof(Ranks)).Length;

        List<Card> stack = [];

        for (int i = 0; i < ammountOfStacks; i++)
            for (int j = 0; j < numberOfDefinedSuits; j++)
                for (int k = 1; k < numberOfDefinedRanks; k++)
                    stack.Add(new Card((Suits)j, (Ranks)k));

        return stack;
    }
}
