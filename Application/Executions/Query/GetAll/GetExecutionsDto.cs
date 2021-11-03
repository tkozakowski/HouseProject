using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Executions.Query.GetAll
{
    public class GetExecutionsDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EstimatedCost { get; set; }
        public string CostPayed { get; set; }
        public string LaborCost { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Execution, GetExecutionsDto>()
                .ForMember(d => d.EstimatedCost, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.EstimatedCost)))
                .ForMember(d => d.CostPayed, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.CostPayed)))
                .ForMember(d => d.LaborCost, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.LaborCost)));
        }
    }
}
