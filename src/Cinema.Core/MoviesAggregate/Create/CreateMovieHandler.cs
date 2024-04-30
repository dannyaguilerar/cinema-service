using Cinema.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Core.MoviesAggregate.Create;

public class CreateMovieHandler(
    ILogger<CreateMovieHandler> _logger,
    ISpecRepository<Movie> _movieSpecRepository)
    : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{        
    public async Task<CreateMovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie { Title = request.Title, Description = request.Description };
        await _movieSpecRepository.AddAsync(movie, cancellationToken);
        _logger.LogInformation($"Movie {movie.Title} created with id {movie.Id}.");
        return new CreateMovieResponse(movie.Id);
    }
}
