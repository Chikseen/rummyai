using RummyAi.Application.Contract.Features.Board;
using RummyAi.Application.Features.Board;
using RummyAi.Application.Features.Seed;

namespace RummyAi.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ISeedService, SeedService>();

        services.AddScoped<IGenerateDeckService, GenerateDeckService>();
    }
}