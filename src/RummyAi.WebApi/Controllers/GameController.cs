using Microsoft.AspNetCore.Mvc;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto.Models;

namespace RummyAi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController(
        IGameService gameService
    ) : ControllerBase
{

    [HttpGet()]
    [Route(nameof(GetGame))]
    public ActionResult<Game> GetGame(Guid? gameId)
        => Ok(gameService.GetGame(new(gameId)));

    [HttpGet()]
    [Route(nameof(AddPlayer))]
    public ActionResult<Game> AddPlayer(Guid? gameId, Guid? playerId)
    {
        if (gameId is null)
            return BadRequest("GameId missing");

        if (playerId is null)
            return BadRequest("PlayerId missing");

        Game game = gameService.AddPlayer(new(gameId), new((Guid)playerId));

        return Ok(game);
    }

    [HttpGet()]
    [Route(nameof(StartGame))]
    public ActionResult<Game> StartGame(Guid? gameId)
    {
        if (gameId is null)
            return BadRequest("GameId missing");

        Game game = gameService.StartGame(new(gameId));

        return Ok(game);
    }
}
