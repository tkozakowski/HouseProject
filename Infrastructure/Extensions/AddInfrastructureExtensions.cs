﻿using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Persistence;
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
            services.AddScoped<IHouseProjectDbContext, HouseProjectDbContext>();
            services.AddCosmos(Configuration);
            services.AddScoped<IODataMaterialRepository, ODataMaterialRepository>();
            
            return services;
        } 
    }
}