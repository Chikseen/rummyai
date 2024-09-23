using Microsoft.AspNetCore.Mvc;
using RummyAi.Application.Contract.Features.Board;

namespace RummyAi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TempDebugController(
        IGenerateDeckService generateBoard
    ) : ControllerBase
{

    [HttpGet()]
    public void Get()
    {
        generateBoard.Random();
    }
}
