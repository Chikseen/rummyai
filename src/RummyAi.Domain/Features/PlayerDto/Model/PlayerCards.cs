using RummyAi.Domain.Features.DeckDto.Models;
using RummyAi.Domain.Features.GameDto;

namespace RummyAi.Domain.Features.PlayerDto.Model;

public class PlayerCards
{
    public PlayerId PlayerId { get; init; }
    public Stack Cards { get; set; }

    public PlayerCards(PlayerId playerId, Stack cards)
    {
        PlayerId = playerId;
        Cards = cards;
    }
}
