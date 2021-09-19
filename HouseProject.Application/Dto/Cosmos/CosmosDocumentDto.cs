using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;

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
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => DateTimeToString.ConvertNullableDateTimeToString(s.ReceivedAt)))
                .ForMember(d => d.Cost, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.Cost)));
        }

    }
}
