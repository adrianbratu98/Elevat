using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElevatDbContext>(opt =>
                    opt.UseNpgsql(configuration.GetConnectionString("ElevatDB")));
            //services.AddScoped<IElevatDbContext>(provider => provider.GetService<ElevatDbContext>());
            services.AddTransient<IElevatDbContext,ElevatDbContext>();

            return services;
        }
    }
}
