using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using System;

namespace Application.Dto.Cosmos
{
    public class CreateCosmosDocumentDto : IMap
    {
        public string Name { get; set; }
        public string ReceivedAt { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCosmosDocumentDto, CosmosDocument>()
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => ConvertStringToDateTime(s.ReceivedAt)))
                .ForMember(d => d.Cost, o => o.MapFrom(s => ConvertToDecimal(s.Cost)));
        }

        private static DateTime? ConvertStringToDateTime(string receivedAt)
        {
            if (string.IsNullOrEmpty(receivedAt))
            {
                return new DateTime();
            }
            
            DateTime result;

            var correct = DateTime.TryParse(receivedAt, out result);

            return correct ? result : new DateTime();
        }

        private static decimal? ConvertToDecimal(string cost)
        {
            if (string.IsNullOrEmpty(cost)) return 0M;

            decimal result;
            var success = Decimal.TryParse(cost, out result);

            return success ? result : 0M;
        }
    }
}

