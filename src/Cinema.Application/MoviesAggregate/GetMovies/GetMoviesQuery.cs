using MediatR;

namespace Cinema.Application.MoviesAggregate.GetMovies;

public class GetMoviesQuery : IRequest<IEnumerable<>>
{

}