using RummyAi.Domain.Features.CardDto.Models;

namespace RummyAi.Domain.Features.CardDto.Enum;

public class Card
{
    public Suits Suit { get; set; }
    public Ranks Rank { get; set; }
    public Guid CardId { get; set; }

    public Card(Suits suit, Ranks rank)
    {
        Suit = suit;
        Rank = rank;
        CardId = Guid.NewGuid();
    }
}