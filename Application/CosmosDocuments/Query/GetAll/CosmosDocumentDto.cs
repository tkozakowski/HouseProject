using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using System;

namespace Application.CosmosDocuments.Query.GetAll
{
    public class CosmosDocumentDto : IMap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosDocument, CosmosDocumentDto>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.Cost)));

            profile.CreateMap<CosmosDocumentDto, CosmosDocument>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.Cost)));
        }

    }
}
