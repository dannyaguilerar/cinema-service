using Cinema.Core.MoviesAggregate.Create;
using Cinema.Core.MoviesAggregate.Delete;
using Cinema.Core.MoviesAggregate.Get;
using Cinema.Core.MoviesAggregate.List;
using Cinema.Core.MoviesAggregate.Update;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Controllers;

public class MoviesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command, CancellationToken token) => Ok(await Mediator.Send(command, token));

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query, CancellationToken token) => Ok(await Mediator.Send(query, token));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie([FromRoute] Guid id, CancellationToken token) => Ok(await Mediator.Send(new GetMovieQuery(id), token));    

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command, CancellationToken token) => Ok(await Mediator.Send(command, token));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] Guid id, CancellationToken token) => Ok(await Mediator.Send(new DeleteMovieCommand(id), token));
}
