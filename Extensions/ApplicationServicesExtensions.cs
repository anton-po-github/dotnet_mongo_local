using dotnet_postgresql_crud.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_mongo_local.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            /*     services.AddDbContext<AppIdentityDbContext>(x =>
                {
                    x.UseNpgsql(config.GetConnectionString("IdentityConnection"));
                });

                services.AddDbContext<DataContext>(x =>
                {
                    x.UseNpgsql(config.GetConnectionString("DefaultConnection"));
                });

                services.AddScoped<ITokenService, TokenService>();
                services.AddScoped<IUserService, UserService>();
     */
            return services;
        }
    }
}