using Microsoft.AspNetCore.Mvc;
using RummyAi.Application.Contract.Features.Board;
using RummyAi.Domain.Features.Deck;

namespace RummyAi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TempDebugController(
        IGenerateDeckService generateBoard
    ) : ControllerBase
{

    [HttpGet()]
    public Stack Get()
    {
        return generateBoard.GenerateRandom();
    }
}
