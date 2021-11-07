using Application.Mappings;
using AutoMapper;
using Domain.Enum;
using System;

namespace Application.Dto.LoanTranche.Query
{
    public class LoanTrancheDto : IMap
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public decimal Amount { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LoanTranche, LoanTrancheDto>()
                .ForMember(d => d.Stage, o => o.MapFrom(s => ConvertToString(s.Stage)));
        }

        private static string ConvertToString(LoanTrancheStage stage)
        {
            var result = Enum.GetName(typeof(LoanTrancheStage), stage);
            return result;
        }

    }
}
