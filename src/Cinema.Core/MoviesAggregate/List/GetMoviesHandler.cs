using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.MoviesAggregate.List;

public class GetMoviesHandler(ISpecReadRepository<Movie> _moviesSpecReadRepository) : IRequestHandler<GetMoviesQuery, GetMoviesResponse>
{
    public async Task<GetMoviesResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var list = await _moviesSpecReadRepository.ListAsync(cancellationToken);
        return new GetMoviesResponse(list);
    }
}
