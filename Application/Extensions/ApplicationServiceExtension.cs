using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using Application.Validators;

namespace Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(opt => 
            {
                opt.RegisterValidatorsFromAssemblyContaining<DocumentDtoValidator>();
            });
            services.AddScoped<IODataMaterialService, ODataMaterialService>();
            services.AddScoped<UserContextAccessorService>();
            services.AddScoped<IAttachmentService, AttachmentComparerService>();
            return services;
        }
    }
}
