using Microsoft.AspNetCore.Mvc;
using RummyAi.Application.Contract.Features.GameContract;
using RummyAi.Domain.Features.GameDto;
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

    [HttpPost()]
    [Route(nameof(AddPlayer))]
    [ServiceFilter(typeof(GameFilter))]
    public ActionResult<Game> AddPlayer(Guid gameId, PlayerId playerId)
        => Ok(gameService.AddPlayer(new(gameId), playerId));

    [HttpGet()]
    [Route(nameof(StartGame))]
    [ServiceFilter(typeof(GameFilter))]
    public ActionResult<Game> StartGame(Guid gameId)
        => Ok(gameService.StartGame(new(gameId)));

    [HttpPost()]
    [Route(nameof(MakeMove))]
    public ActionResult<Game> MakeMove(Move move)
        => Ok(gameService.MakeMove(move));
}