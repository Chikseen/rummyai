namespace RummyAi.Application.Contract.Features.RandomContract;

public interface IRandomService
{
    public int GetRandomRange(int min, int max);
    public Random GetRandom();
}