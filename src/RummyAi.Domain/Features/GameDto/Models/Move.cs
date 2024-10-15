using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Domain.Features.GameDto.Models;

public class Move
{
    public required GameId GameId { get; set; }
    public required PlayerId PlayerId { get; set; }
    public required List<Card> Cards { get; set; }
}
