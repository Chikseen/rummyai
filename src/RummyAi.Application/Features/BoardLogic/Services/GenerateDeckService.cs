using Microsoft.Extensions.Options;
using RummyAi.Application.Contract.Features.BoardContract;
using RummyAi.Application.Contract.Features.RandomContract;
using RummyAi.Application.Extensions.StackProvider;
using RummyAi.Domain.Features;
using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.CardDto.Models;
using RummyAi.Domain.Features.DeckDto.Models;

namespace RummyAi.Application.Features.BoardLogic.Services;

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
