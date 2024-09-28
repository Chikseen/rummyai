using RummyAi.Domain.Features.CardDto.Models;

namespace RummyAi.Domain.Features.CardDto.Enum;

public record Card(
    Suits Suit,
    Ranks Rank);