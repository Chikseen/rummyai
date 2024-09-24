namespace RummyAi.Application.Contract.Features.RandomProvider;

public interface IRandomService
{
    public int GetRandomRange(int min, int max);
    public Random GetRandom();
}