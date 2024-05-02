using Ardalis.Specification;

namespace Cinema.Core.TheatersAggregate.List;

public class GetTheatersSpecification : Specification<Theater>
{
    public GetTheatersSpecification(int skip, int take)
    {
        Query.Skip(skip).Take(take);
    }
}
