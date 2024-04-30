using MediatR;

namespace Cinema.Core.MoviesAggregate.Delete;

public record DeleteMovieCommand(Guid Id) : IRequest<DeleteMovieResponse>;