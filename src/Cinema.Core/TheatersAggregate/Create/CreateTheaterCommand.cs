using MediatR;

namespace Cinema.Core.TheatersAggregate.Create;

public record CreateTheaterCommand(string Name, string? Address) : IRequest<CreateTheaterResponse>;