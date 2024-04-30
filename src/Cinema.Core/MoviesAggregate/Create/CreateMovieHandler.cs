using Cinema.Core.Interfaces;
using Cinema.Core.MoviesAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.MoviesAggregate.Create
{
    public class CreateMovieHandler(
        ILogger<CreateMovieHandler> _logger,
        ISpecRepository<Movie> _movieSpecRepository)
        : IRequestHandler<CreateMovieCommand, Guid>
    {        
        public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie { Title = request.Title, Description = request.Description };
            await _movieSpecRepository.AddAsync(movie);
            return movie.Id;
        }
    }
}
