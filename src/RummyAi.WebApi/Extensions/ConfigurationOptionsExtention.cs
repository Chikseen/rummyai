using RummyAi.Domain.Features;

namespace RummyAi.WebApi.Extensions;

public static class ConfigurationOptionsExtention
{
    public static void AddOption(this IServiceCollection services)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfiguration config = configBuilder.Build();
        services.Configure<ConfigurationOptions>(config.GetSection(nameof(ConfigurationOptions)));
    }
}
