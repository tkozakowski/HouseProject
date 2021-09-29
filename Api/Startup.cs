using Api.Extensions;
using Api.Middleware;
using Application.Dto;
using Application.Dto.Materials;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using System;

namespace HouseProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HouseProject.Api v1"));
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHealthChecks("/health", new HealthCheckOptions 
            {
                ResponseWriter = async (context, report) => 
                {
                    context.Response.ContentType = IMime
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.EnableDependencyInjection();
                //endpoints.Filter().OrderBy().MaxTop(10);
                //endpoints.MapODataRoute("odata", "odata", GetEdmModel());
                endpoints.MapControllers();
            });
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<GetMaterialsDto>("Materials");
            return builder.GetEdmModel();
        }
    }
}
