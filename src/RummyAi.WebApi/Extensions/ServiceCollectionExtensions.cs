using RummyAi.Application.Contract.Features.Board;
using RummyAi.Application.Contract.Features.RandomProvider;
using RummyAi.Application.Features.Board;
using RummyAi.Application.Features.RandomProvider;

namespace RummyAi.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IRandomService, SeedService>();

        services.AddScoped<IGenerateDeckService, GenerateDeckService>();
    }
}