using Ardalis.Specification;

namespace Cinema.Core.MoviesAggregate.Specifications;

internal class MovieExistsByTitleSpecification : Specification<Movie, bool>
{
    public MovieExistsByTitleSpecification(string title)
    {
        Query.Where(x => x.Title == title);
        Query.Select(x => x != null);
    }
}
