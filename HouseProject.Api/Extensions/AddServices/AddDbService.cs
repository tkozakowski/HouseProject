using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.AddServices
{
    public static class AddDbService
    {
        public static IServiceCollection AddHouseDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HouseProjectDbContext>(opt => 
            {
                opt.UseSqlServer(configuration.GetConnectionString("HouseProjectConnection"));
            });
            return services;
        }
    }
}
