using RummyAi.Domain.Features.DeckDto.Models;

namespace RummyAi.Domain.Features.GameDto.Models;

public class Move
{
    public required GameId GameId { get; set; }
    public required PlayerId PlayerId { get; set; }
    public required Stack Stack { get; set; }
}
