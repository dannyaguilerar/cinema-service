using MediatR;

namespace Cinema.Core.TheatersAggregate.List;

public record GetTheatersQuery(int Skip = 0, int Take = 10) : IRequest<GetTheatersResponse>;
