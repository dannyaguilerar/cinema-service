using Ardalis.Specification;

namespace Cinema.Core.MoviesAggregate.List;

internal class GetMoviesSpecification : Specification<Movie>
{
    public GetMoviesSpecification(int skip, int take)
    {
        Query.Skip(skip).Take(take);            
    }
}
