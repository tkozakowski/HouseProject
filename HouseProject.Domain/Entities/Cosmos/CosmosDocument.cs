using Cosmonaut.Attributes;
using Newtonsoft.Json;
using System;

namespace Domain.Entities.Cosmos
{
    [CosmosCollection("documents")]
    public class CosmosDocument
    {
        [CosmosPartitionKey]
        [JsonProperty]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }

    }
}
