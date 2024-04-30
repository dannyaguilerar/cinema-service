using MediatR;

namespace Cinema.Core.MoviesAggregate.Create;

public record CreateMovieCommand(string Title, string? Description) : IRequest<CreateMovieResponse>;