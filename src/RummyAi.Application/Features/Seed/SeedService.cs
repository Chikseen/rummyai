using Microsoft.Extensions.Options;
using RummyAi.Application.Contract.Features.Board;
using RummyAi.Domain.Features;

namespace RummyAi.Application.Features.Seed;

public class SeedService(
        IOptions<ConfigurationOptions> options
    ) : ISeedService
{
    public int GetSeed()
    {
        bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        if (isDevelopment)
            return options.Value.Seed;

        return new Random().Next();
    }
}