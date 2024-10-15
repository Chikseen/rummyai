using Microsoft.ML.Data;

namespace RummyAi.Domain.MachineLearning;

public class MoveDataPrediction
{
    [ColumnName("Score")]
    public float PredictedGoodMove { get; set; }
}
