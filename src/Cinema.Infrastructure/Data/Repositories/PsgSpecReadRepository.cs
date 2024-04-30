using Ardalis.Specification.EntityFrameworkCore;
using Cinema.Core.Interfaces;

namespace Cinema.Infrastructure.Data.Repositories
{
    public class PsgSpecReadRepository<T> : RepositoryBase<T>, ISpecReadRepository<T> where T : class, IAggregateRoot
    {
        public PsgSpecReadRepository(CinemaDbContext dbContext) : base(dbContext) { }
    }
}
