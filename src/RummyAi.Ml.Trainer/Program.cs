using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using RummyAi.Domain.MachineLearning;
using System.Numerics;
using System.Security.AccessControl;
using System.Text.Json;
using static Microsoft.ML.DataOperationsCatalog;

Console.WriteLine("Start\n");

MLContext mlContext = new();

List<MoveData> moveIos = JsonSerializer.Deserialize<List<MoveData>>(File.ReadAllText("I:/_User/Desktop/test.json"))!;

//IEnumerable<Vector3> rawData = moveIos.Select(move => new Vector3(move.Cards.Select(card => new Vector2((float)card.Suit, (float)card.Rank)).First(), 1f));

var rawData = moveIos.Select(move => new DataPointVector()
{
    Label = move.IsMoveValid,
    Features = move.Cards.Select(card => new Vector2((float)card.Suit, (float)card.Rank)).Select(vector => vector.LengthSquared()).ToArray()
});

IDataView data = mlContext.Data.LoadFromEnumerable(rawData);

var featureColumn = data.Schema["Features"].Type as VectorDataViewType;
// Inspecting the schema
Console.WriteLine($"Is the size of the Features column known: " +
    $"{featureColumn.IsKnownSize}.\nSize: {featureColumn.Size}");

TrainTestData dataSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.1);

IDataView trainData = dataSplit.TrainSet;
IDataView testData = dataSplit.TestSet;

SdcaRegressionTrainer sdcaEstimator = mlContext.Regression.Trainers.Sdca();
RegressionPredictionTransformer<LinearRegressionModelParameters> trainedModel = sdcaEstimator.Fit(trainData);

// Use trained model to make inferences on test data
IDataView testDataPredictions = trainedModel.Transform(testData);

// Extract model metrics and get RSquared
RegressionMetrics trainedModelMetrics = mlContext.Regression.Evaluate(testDataPredictions);
double rSquared = trainedModelMetrics.RSquared;

File.Delete("I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip");
mlContext.Model.Save(trainedModel, data.Schema, "I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip");

////////////

ITransformer predictionPipeline = mlContext.Model.Load("I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip", out DataViewSchema predictionPipelineSchema);

PredictionEngine<DataPointVector, MoveDataPrediction> predictionEngine = mlContext.Model.CreatePredictionEngine<DataPointVector, MoveDataPrediction>(predictionPipeline);

var s = predictionEngine.OutputSchema;

///

Vector2[] cards = [
    new Vector2(0, 5),
    new Vector2(0, 7)
];

// 0 5 0 7  - 1 - 0.230140463, 0.238468468, 0.234113351
// 1 4 3 12 - 0 - 0.235046849, 0.229452789, 0.238585323

DataPointVector inputData = new()
{
    Features = [cards[0].Length(), cards[1].Length()]
};

var p = predictionEngine.Predict(inputData);

Console.WriteLine("End\n");


/*
DataDebuggerPreview preview = data.Preview();
foreach (DataViewSchema.Column column in preview.Schema)
{
    Console.WriteLine($"{column.Name} - {column.Type}");
}
TrainTestData dataSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
IDataView trainData = dataSplit.TrainSet;
IDataView testData = dataSplit.TestSet;
/*
IEstimator<ITransformer> dataPrepEstimator =
    mlContext.Transforms.Concatenate("Features", new string[] { "MoveRanks", "MoveSuits" })
        .Append(mlContext.Transforms.NormalizeMinMax("Features"))
        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "IsMoveValid"));/*

IEstimator<ITransformer> dataPrepEstimator =
        mlContext.Transforms.NormalizeMinMax("MoveRanks")
        .Append(mlContext.Transforms.NormalizeMinMax("MoveSuits"))
        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "IsMoveValid"));

ITransformer dataPrepTransformer = dataPrepEstimator.Fit(trainData);

IDataView transformedTrainingData = dataPrepTransformer.Transform(trainData);

SdcaRegressionTrainer sdcaEstimator = mlContext.Regression.Trainers.Sdca(labelColumnName: "IsMoveValid");

RegressionPredictionTransformer<LinearRegressionModelParameters> trainedModel = sdcaEstimator.Fit(transformedTrainingData);

IDataView transformedTestData = dataPrepTransformer.Transform(testData);

// Use trained model to make inferences on test data
IDataView testDataPredictions = trainedModel.Transform(transformedTestData);

// Extract model metrics and get RSquared
RegressionMetrics trainedModelMetrics = mlContext.Regression.Evaluate(testDataPredictions, labelColumnName: "IsMoveValid");
double rSquared = trainedModelMetrics.RSquared;

File.Delete("I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip");
mlContext.Model.Save(trainedModel, data.Schema, "I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip");

///
List<MoveDataT> inputData = [new()
{
    Features = [0,0,0,0],
    MoveSuits = [0,0],
    MoveRanks = [1,4]
}];

DataViewSchema predictionPipelineSchema;
ITransformer predictionPipeline = mlContext.Model.Load("I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip", out predictionPipelineSchema);

PredictionEngine<MoveDataT, MoveDataPrediction> predictionEngine = mlContext.Model.CreatePredictionEngine<MoveDataT, MoveDataPrediction>(predictionPipeline);

var s = predictionEngine.OutputSchema;

var p = predictionEngine.Predict(inputData[0]);
///

Console.WriteLine(trainedModel);


public class MoveDataT
{
    [ColumnName(nameof(Features))]
    [VectorType(4)]
    public float[] Features { get; set; }

    [VectorType()]
    [ColumnName(nameof(MoveSuits))]
    public float[] MoveSuits { get; set; }

    [VectorType()]
    [ColumnName(nameof(MoveRanks))]
    public float[] MoveRanks { get; set; }

    [ColumnName(nameof(IsMoveValid))]
    public float IsMoveValid { get; set; }
}
*/

public class DataPointVector
{
    public float Label { get; set; }

    [VectorType(2)]
    public float[] Features { get; set; }
}