﻿using Microsoft.Extensions.Options;
using RummyAi.Application.Contract.Features.RandomProvider;
using RummyAi.Domain.Features;

namespace RummyAi.Application.Features.RandomProvider;

public class SeedService(
        IOptions<ConfigurationOptions> options
    ) : IRandomService
{
    public int GetRandomRange(int min, int max)
    {
        Random random = GenerateRandom();
        return random.Next(min, max);
    }

    public Random GetRandom()
    {
        Random random = GenerateRandom();
        return random;
    }

    private Random GenerateRandom()
    {
        bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        if (isDevelopment)
            return new Random(Seed: options.Value.Seed);

        return new Random();
    }
}