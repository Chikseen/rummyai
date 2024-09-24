using RummyAi.Domain.Features.Deck;

namespace RummyAi.Application.Contract.Features.Board;

public interface IGenerateDeckService
{
    Stack GenerateRandom();
}