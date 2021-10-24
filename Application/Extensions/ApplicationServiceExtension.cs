using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using Application.Documents.Command.CreateDocument;
using MediatR;

namespace Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(opt => 
            {
                opt.RegisterValidatorsFromAssemblyContaining<CreateDocumentDtoValidator>();
            });
            services.AddScoped<IODataMaterialService, ODataMaterialService>();
            services.AddScoped<UserContextAccessorService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
