namespace RummyAi.WebApi.Extensions;

public static class AddCorsExtension
{
    public static void AddCorsSettings(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "CorsOptions",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000",
                                        "http://www.contoso.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });
    }
}
