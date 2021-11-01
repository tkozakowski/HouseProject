using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Executions.Command.Add
{
    public class AddExecutionDto: IMap
    {
        public string Name { get; set; }
        public string EstimatedCost { get; set; }
        public string LaborCost { get; set; }
        public string CostPayed { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int WorkStageID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddExecutionDto, Execution>()
                .ForMember(d => d.EstimatedCost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.EstimatedCost)))
                .ForMember(d => d.LaborCost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.LaborCost)))
                .ForMember(d => d.CostPayed, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.CostPayed)));
        }
    }
}
