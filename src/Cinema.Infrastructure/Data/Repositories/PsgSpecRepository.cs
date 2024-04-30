using Ardalis.Specification.EntityFrameworkCore;
using Cinema.Core.Interfaces;

namespace Cinema.Infrastructure.Data.Repositories;

public class PsgSpecRepository<T>(CinemaDbContext dbContext) : RepositoryBase<T>(dbContext), ISpecRepository<T> where T : class, IAggregateRoot;