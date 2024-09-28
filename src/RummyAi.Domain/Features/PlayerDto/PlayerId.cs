namespace RummyAi.Domain.Features.GameDto;

public record PlayerId(Guid Id)
{
    public static implicit operator PlayerId(Guid id) => new(id);
}