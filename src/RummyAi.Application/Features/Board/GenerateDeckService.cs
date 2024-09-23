using RummyAi.Application.Contract.Features.Board;

namespace RummyAi.Application.Features.Board;

public class GenerateDeckService(
        ISeedService seedService
    ) : IGenerateDeckService
{
    public void Random()
    {
        Random random = new(Seed: seedService.GetSeed());
        int t = random.Next(0, 100);
        Console.WriteLine("Hello World");
    }
}
