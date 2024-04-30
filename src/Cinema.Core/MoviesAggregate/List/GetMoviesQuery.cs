using MediatR;

namespace Cinema.Core.MoviesAggregate.List;

public record GetMoviesQuery(int Skip = 0, int Take = 10) : IRequest<GetMoviesResponse>;