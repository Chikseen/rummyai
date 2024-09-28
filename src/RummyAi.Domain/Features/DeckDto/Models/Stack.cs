using RummyAi.Domain.Features.CardDto.Enum;

namespace RummyAi.Domain.Features.DeckDto.Models;

public class Stack
{
    public List<Card> Cards { get; set; } = [];

    public Stack()
    {
        Cards = [];
    }

    public Stack(List<Card> cards)
    {
        Cards = cards;
    }
}
