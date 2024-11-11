using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.CardDto.Enum;
using RummyAi.Domain.Features.DeckDto.Models;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.MachineLearning;

namespace RummyAi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DebugController(
        IGameService gameService
    ) : ControllerBase
{

    [HttpGet()]
    [Route(nameof(GenerateRandomMoves))]
    public void GenerateRandomMoves()
    {
        for (int i = 0; i < 5000; i++)
        {
            Game game = gameService.GetGame(Guid.NewGuid());
            Game startedGame = gameService.StartGame(game.GameId);

            List<Card> moveCards = startedGame.PlayerCards
                .Where(player => player.PlayerId == startedGame.CurrentPlayer!.PlayerId)
                .First()
                .Stack.Cards
                .Take(2)
                .ToList();

            Stack cards = new()
            {
                Cards = moveCards
            };

            Move move = new()
            {
                GameId = startedGame.GameId,
                PlayerId = startedGame.CurrentPlayer!.PlayerId,
                Stack = cards
            };

            MoveResult movedGame = gameService.MakeMove(move);
        }
    }

    [HttpGet()]
    [Route(nameof(PredictMove))]
    public void PredictMove()
    {
        MLContext mlContext = new();

        // Load Trained Model
        DataViewSchema predictionPipelineSchema;
        ITransformer predictionPipeline = mlContext.Model.Load("I:/_User/Desktop/rummyai/src/RummyAi.Ml.Trainer/TraniedModels/v1.zip", out predictionPipelineSchema);

        // Create PredictionEngines
        PredictionEngine<MoveData, MoveDataPrediction> predictionEngine = mlContext.Model.CreatePredictionEngine<MoveData, MoveDataPrediction>(predictionPipeline);

        MoveData inputData = new()
        {

        };

        MoveDataPrediction prediction = predictionEngine.Predict(inputData);
        Console.WriteLine($"Fare Amount: {prediction.PredictedGoodMove}");
    }
}