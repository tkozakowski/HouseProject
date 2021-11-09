using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Preparations.Query.GetAll
{
    public class GetPreparationsDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public decimal? Advance { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? FinanceId { get; set; }
        public List<DocumentDto> Documents { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Preparation, GetPreparationsDto>()
                .ForMember(s => s.Documents, o => o.MapFrom(d => d.Documents));
            profile.CreateMap<Domain.Entities.Document, DocumentDto>();
        }
    }
}
