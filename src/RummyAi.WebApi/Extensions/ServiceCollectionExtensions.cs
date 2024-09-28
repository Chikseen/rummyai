using RummyAi.Application.Contract.Features.BoardContract;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Application.Contract.Features.RandomContract;
using RummyAi.Application.Features.BoardLogic.Services;
using RummyAi.Application.Features.GameLogic.Services;
using RummyAi.Application.Features.RandomLogic.Services;

namespace RummyAi.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IGameStateService, GameStateService>();

        services.AddScoped<IRandomService, RandomService>();
        services.AddScoped<IGenerateDeckService, GenerateDeckService>();

        // Game
        services.AddScoped<IGameAddPlayerService, GameAddPlayerService>();
        services.AddScoped<IGameGetService, GameGetService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IGameStartService, GameStartService>();
    }
}