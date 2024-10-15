using Microsoft.ML.Data;
using RummyAi.Domain.Features.CardDto.Enum;

namespace RummyAi.Domain.MachineLearning;

public class MoveData
{
    [LoadColumn(0)]
    public float IsMoveValid { get; set; }

    public List<Card> Cards { get; set; }
}

public class MoveCard
{
    [KeyType(13)]
    public uint Suit { get; set; }

    [KeyType(13)]
    public uint Rank { get; set; }
}
