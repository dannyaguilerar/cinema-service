using Cinema.Core.Exceptions;
using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.MoviesAggregate.Get;

public class GetMovieHandler(ISpecReadRepository<Movie> _moviesSpecReadRepository) : 
    IRequestHandler<GetMovieQuery, GetMovieResponse>
{

    public async Task<GetMovieResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _moviesSpecReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (movie == null) { throw new RecordNotFoundException(nameof(Movie), request.Id.ToString()); }

        return new GetMovieResponse(movie);
    }
}
