using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.MoviesAggregate.List;

public class GetMoviesHandler(ISpecReadRepository<Movie> _moviesSpecReadRepository) : IRequestHandler<GetMoviesQuery, GetMoviesResponse>
{
    public async Task<GetMoviesResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetMoviesSpecification(request.Skip, request.Take);
        var movies = await _moviesSpecReadRepository.ListAsync(spec, cancellationToken);
        return new GetMoviesResponse(movies);
    }
}
