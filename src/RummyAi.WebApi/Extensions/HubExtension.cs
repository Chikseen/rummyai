using RummyAi.Domain.Hubs;

namespace RummyAi.WebApi.Extensions;

public static class HubExtension
{
    public static void AddHubs(this WebApplication app)
    {
        app.MapHub<GameHub>("/gamehub");
    }
}