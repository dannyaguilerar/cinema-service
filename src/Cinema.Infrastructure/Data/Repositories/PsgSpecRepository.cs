using Ardalis.Specification.EntityFrameworkCore;
using Cinema.Core.Interfaces;

namespace Cinema.Infrastructure.Data.Repositories
{
    public class PsgSpecRepository<T> : RepositoryBase<T>, ISpecRepository<T> where T : class
    {
        public PsgSpecRepository(CinemaDbContext dbContext) : base(dbContext) { }
    }
}
