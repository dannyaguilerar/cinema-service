using MediatR;

namespace Cinema.Core.MoviesAggregate.Update;

public record UpdateMovieCommand(Guid Id, string? Title, string? Description) : IRequest<UpdateMovieResponse>;