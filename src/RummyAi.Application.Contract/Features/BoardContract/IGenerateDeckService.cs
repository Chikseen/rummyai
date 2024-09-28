using RummyAi.Domain.Features.DeckDto.Models;

namespace RummyAi.Application.Contract.Features.BoardContract;

public interface IGenerateDeckService
{
    Stack GenerateRandom();
}