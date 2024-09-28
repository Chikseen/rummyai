using RummyAi.Domain.Features.DeckDto.Models;

namespace RummyAi.Application.Extensions.StackProvider;

public static class StackExtensions
{
    public static void Shuffle(this Stack stack, Random random)
    {
        stack.Cards = stack.Cards.OrderBy(x => random.NextDouble()).ToList();
    }
}
