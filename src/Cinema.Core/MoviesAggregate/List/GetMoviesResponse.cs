namespace Cinema.Core.MoviesAggregate.List;

public record GetMoviesResponse(IEnumerable<Movie> Movies);