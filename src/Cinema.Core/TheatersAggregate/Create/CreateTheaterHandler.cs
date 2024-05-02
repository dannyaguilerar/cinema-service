using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.TheatersAggregate.Create;

public class CreateTheaterHandler(ISpecRepository<Theater> _theaterSpecRepository) : 
    IRequestHandler<CreateTheaterCommand, CreateTheaterResponse>
{

    public async Task<CreateTheaterResponse> Handle(CreateTheaterCommand request, CancellationToken cancellationToken)
    {
        var theater = new Theater { Name = request.Name, Address = request.Address };
        await _theaterSpecRepository.AddAsync(theater, cancellationToken);

        await _theaterSpecRepository.SaveChangesAsync(cancellationToken);

        return new CreateTheaterResponse(theater.Id);
    }
}
