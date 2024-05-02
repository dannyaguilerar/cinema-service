using Cinema.Core.MoviesAggregate;
using Cinema.Core.TheatersAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cinema.Infrastructure.Data;

public class CinemaDbContext(DbContextOptions<CinemaDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;database=cinemadb;user id=postgres;password=postgres;");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
