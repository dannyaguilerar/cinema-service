using MediatR;

namespace Cinema.Application.MoviesAggregate.Create;

public record CreateMovieCommand(string Title, string? Description) : IRequest<Guid>;