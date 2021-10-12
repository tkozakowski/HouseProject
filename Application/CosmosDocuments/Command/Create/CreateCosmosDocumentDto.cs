using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using System;

namespace Application.CosmosDocuments.Command.Create
{
    public class CreateCosmosDocumentDto : IMap
    {
        public string Name { get; set; }
        public string Stage { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCosmosDocumentDto, CosmosDocument>();
        }

    }
}

