using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.TheatersAggregate.List;

public class GetTheatersHandler(ISpecReadRepository<Theater> _theaterSpecReadRepository) : 
    IRequestHandler<GetTheatersQuery, GetTheatersResponse>
{
    public async Task<GetTheatersResponse> Handle(GetTheatersQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetTheatersSpecification(request.Skip, request.Take);
        var theaters = await _theaterSpecReadRepository.ListAsync(spec, cancellationToken);

        return new GetTheatersResponse(theaters);
    }
}
