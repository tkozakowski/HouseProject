using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using Application.Conversions;

namespace Application.Dto.Cosmos
{
    public class CreateCosmosDocumentDto : IMap
    {
        public string Name { get; set; }
        public string Stage { get; set; }
        public string ReceivedAt { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCosmosDocumentDto, CosmosDocument>()
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => StringToDateTime.ConvertStringToDateTime(s.ReceivedAt)))
                .ForMember(d => d.Cost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.Cost)));
        }

    }
}

