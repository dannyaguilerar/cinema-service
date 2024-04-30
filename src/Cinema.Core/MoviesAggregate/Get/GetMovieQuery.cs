using MediatR;

namespace Cinema.Core.MoviesAggregate.Get;

public record GetMovieQuery(Guid Id) : IRequest<GetMovieResponse>;
