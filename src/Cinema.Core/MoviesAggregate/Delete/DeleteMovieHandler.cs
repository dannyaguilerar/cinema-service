using Cinema.Core.Exceptions;
using Cinema.Core.Interfaces;
using MediatR;

namespace Cinema.Core.MoviesAggregate.Delete;

public class DeleteMovieHandler(ISpecRepository<Movie> _moviesSpecRepository) : IRequestHandler<DeleteMovieCommand, DeleteMovieResponse>
{
    public async Task<DeleteMovieResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _moviesSpecRepository.GetByIdAsync(request.Id, cancellationToken);
        if (movie == null) { throw new RecordNotFoundException(nameof(Movie), request.Id.ToString()); }

        await _moviesSpecRepository.DeleteAsync(movie, cancellationToken);
        await _moviesSpecRepository.SaveChangesAsync(cancellationToken);

        return new DeleteMovieResponse();
    }
}
