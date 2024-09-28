namespace RummyAi.Domain.Features;

public class ConfigurationOptions
{
    public int Seed { get; set; }
    public int AmmountOfStacks { get; set; } = 2;
    public int InitNumberOfCardsPerPlayer { get; set; } = 12;
}
