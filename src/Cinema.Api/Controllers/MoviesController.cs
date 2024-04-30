using Cinema.Core.MoviesAggregate.Create;
using Cinema.Core.MoviesAggregate.List;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Controllers;

public class MoviesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query, CancellationToken token) => Ok(await Mediator.Send(query, token));

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command, CancellationToken token) => Ok(await Mediator.Send(command, token));

}
