using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class AddInfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHouseDbContext(Configuration);
            services.AddCosmos(Configuration);
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<ILoanTrancheRepository, LoanTrancheRepository>();
            services.AddScoped<IODataMaterialRepository, ODataMaterialRepository>();
            
            return services;
        } 
    }
}
