using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using System;

namespace Application.Dto.Cosmos
{
    public class CosmosDocumentDto : IMap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReceivedAt { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosDocument, CosmosDocumentDto>()
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => ConvertNullableDateTimeToString(s.ReceivedAt)))
                .ForMember(d => d.Cost, o => o.MapFrom(s => ConvertNullableDecimalToString(s.Cost)));
        }

        private static string ConvertNullableDateTimeToString(DateTime? receivedAt)
        {
            if (receivedAt is null) return String.Empty;
            return receivedAt.ToString();
        }

        private static string ConvertNullableDecimalToString(decimal? cost)
        {
            if (cost is null) return String.Empty;
            return cost.ToString();
        }
    }
}
