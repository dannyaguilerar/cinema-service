using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinema.Application
{
    public static class Configuration
    {
        public static void AddKahaltiolCore(this IServiceCollection services)
        {            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
