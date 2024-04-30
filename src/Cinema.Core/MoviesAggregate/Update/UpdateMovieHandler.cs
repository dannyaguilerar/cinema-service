using Cinema.Core.Exceptions;
using Cinema.Core.Interfaces;
using Cinema.Core.MoviesAggregate.Specifications;
using MediatR;

namespace Cinema.Core.MoviesAggregate.Update;

public class UpdateMovieHandler(ISpecRepository<Movie> _moviesSpecRepository) : 
    IRequestHandler<UpdateMovieCommand, UpdateMovieResponse>
{
    public async Task<UpdateMovieResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _moviesSpecRepository.GetByIdAsync(request.Id, cancellationToken);
        if (movie == null) { throw new RecordNotFoundException(nameof(Movie), request.Id.ToString()); }

        if (!String.IsNullOrWhiteSpace(request.Title) && movie.Title != request.Title) 
        {
            var spec = new MovieExistsByTitleSpecification(request.Title);
            var exists = await _moviesSpecRepository.FirstOrDefaultAsync(spec, cancellationToken);
            if (exists) { throw new DuplicateValueException(nameof(request.Title), request.Title); }

            movie.Title = request.Title;
        }

        movie.Description = request.Description;

        await _moviesSpecRepository.SaveChangesAsync(cancellationToken);

        return new UpdateMovieResponse(movie);
    }
}
