using Cinema.Core.Interfaces;

namespace Cinema.Core.MoviesAggregate
{
    public class Movie : IAggregateRoot
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
