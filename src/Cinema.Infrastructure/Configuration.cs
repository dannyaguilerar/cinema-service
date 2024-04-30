using Cinema.Core.Interfaces;
using Cinema.Infrastructure.Data;
using Cinema.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Infrastructure;

public static class Configuration
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<CinemaDbContext>(config =>
        {
            config.UseNpgsql(@"host=localhost;database=cinemadb;user id=postgres;password=postgres;");
        });
        services.AddScoped(typeof(ISpecRepository<>), typeof(PsgSpecRepository<>));
        services.AddScoped(typeof(ISpecReadRepository<>), typeof(PsgSpecReadRepository<>));
    }
}
