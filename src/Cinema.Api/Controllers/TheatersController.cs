using Cinema.Core.TheatersAggregate.Create;
using Cinema.Core.TheatersAggregate.List;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Controllers;

public class TheatersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateTheater([FromBody] CreateTheaterCommand command, CancellationToken token) => Ok(await Mediator.Send(command, token));

    [HttpGet]
    public async Task<IActionResult> GetTheaters([FromQuery] GetTheatersQuery query, CancellationToken token) => Ok(await Mediator.Send(query, token));
}
