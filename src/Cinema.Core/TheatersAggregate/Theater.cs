using Cinema.Core.Interfaces;

namespace Cinema.Core.TheatersAggregate;

public class Theater : IAggregateRoot
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
}
