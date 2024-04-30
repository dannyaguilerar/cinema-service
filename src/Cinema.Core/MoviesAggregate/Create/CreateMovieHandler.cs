using Cinema.Core.Exceptions;
using Cinema.Core.Interfaces;
using Cinema.Core.MoviesAggregate.Specifications;
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
        var spec = new MovieExistsByTitleSpecification(request.Title);
        var exists = await _movieSpecRepository.FirstOrDefaultAsync(spec, cancellationToken);
        if (exists) { throw new DuplicateValueException(nameof(request.Title), request.Title); }

        var movie = new Movie { Title = request.Title, Description = request.Description };
        await _movieSpecRepository.AddAsync(movie, cancellationToken);
        _logger.LogInformation("Movie {@Title} created with id {@Id}.", movie.Title, movie.Id);
        return new CreateMovieResponse(movie.Id);
    }
}
