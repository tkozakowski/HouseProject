using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.LoanTranche
{
    public class LoanTrancheDto : IMap
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public decimal Amount { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoanTrancheDto, Domain.Entities.LoanTranche>()
                .ForMember(d => d.Stage, o => o.MapFrom(s => ConvertToEnum(s.Stage)));

            profile.CreateMap<Domain.Entities.LoanTranche, LoanTrancheDto>()
                .ForMember(d => d.Stage, o => o.MapFrom(s => ConvertToString(s.Stage)));
        }



        private static LoanTrancheStage ConvertToEnum(string value)
        {
            var result = StringToEnum.ToEnum<LoanTrancheStage>(value, LoanTrancheStage.None);
            return result;
        }

        private static string ConvertToString(LoanTrancheStage stage)
        {
            var result = Enum.GetName(typeof(LoanTrancheStage), stage);
            return result;
        }

    }
}
