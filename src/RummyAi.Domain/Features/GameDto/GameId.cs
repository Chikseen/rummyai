namespace RummyAi.Domain.Features.GameDto;

public record GameId(Guid? Id)
{
    public static implicit operator GameId(Guid id) => new(id);
}