using Application.Core;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Preparations.Command.Add
{
    public class AddPreparationCommand: IRequest<Result<Unit>>, IMap
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public decimal? Advance { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? FinanceId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddPreparationCommand, Preparation>();
        }
    }
}
