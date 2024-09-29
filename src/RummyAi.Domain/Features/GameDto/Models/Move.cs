using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Domain.Features.GameDto.Models;

public class Move
{
    public required Player Player { get; set; }
    public required List<Card> Cards { get; set; }
}
