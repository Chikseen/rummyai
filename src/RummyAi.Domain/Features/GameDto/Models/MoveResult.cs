namespace RummyAi.Domain.Features.GameDto.Models;

public record MoveResult(
    Game Game,
    Move Move,
    bool IsMoveValid);

