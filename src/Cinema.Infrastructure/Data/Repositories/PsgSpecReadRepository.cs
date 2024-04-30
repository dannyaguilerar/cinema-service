using Ardalis.Specification.EntityFrameworkCore;
using Cinema.Core.Interfaces;

namespace Cinema.Infrastructure.Data.Repositories;

public class PsgSpecReadRepository<T>(CinemaDbContext dbContext) : RepositoryBase<T>(dbContext), ISpecReadRepository<T> where T : class, IAggregateRoot;
