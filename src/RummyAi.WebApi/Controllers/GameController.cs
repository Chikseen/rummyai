using Microsoft.AspNetCore.Mvc;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.WebApi.ActionFilterAttributes;

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
    [ServiceFilter(typeof(GameFilter))]
    [ServiceFilter(typeof(PlayerFilter))]
    public ActionResult<Game> AddPlayer(Guid gameId, Guid playerId)
        => Ok(gameService.AddPlayer(new(gameId), new(playerId)));

    [HttpGet()]
    [Route(nameof(StartGame))]
    [ServiceFilter(typeof(GameFilter))]
    public ActionResult<Game> StartGame(Guid gameId)
        => Ok(gameService.StartGame(new(gameId)));

    [HttpPost()]
    [Route(nameof(MakeTurn))]
    [ServiceFilter(typeof(GameFilter))]
    [ServiceFilter(typeof(PlayerFilter))]
    public ActionResult<Game> MakeTurn(Guid gameId, Guid playerId, [FromBody] Move move)
        => Ok(gameService.MakeTurn(gameId, playerId, move));
}