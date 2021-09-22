using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Domain.Entities.Cosmos;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Extensions
{
    public static class CosmosService
    {
        public static IServiceCollection AddCosmos(this IServiceCollection services, IConfiguration Configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
                Configuration["CosmosSettings:DatabaseName"],
                Configuration["CosmosSettings:AccountUri"],
                Configuration["CosmosSettings:AccountKey"],
                new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp }
                );

            services.AddCosmosStore<CosmosDocument>(cosmosStoreSettings);
            return services;
        }
    }
}
