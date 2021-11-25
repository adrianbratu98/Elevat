using Application.Common.Interfaces;
using Elevat.Infrastructure.Identity;
using Infrastructure.Indentity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            services.AddDbContext<ElevatDbContext>(opt =>
                    opt.UseNpgsql(configuration.GetConnectionString("ElevatDB")));

            //Idenitity
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ElevatDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });


            services.AddTransient<IElevatDbContext, ElevatDbContext>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
