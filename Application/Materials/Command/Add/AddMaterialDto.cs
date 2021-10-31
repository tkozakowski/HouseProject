using Application.Conversions;
using Application.Extensions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Command.Add
{
    public class AddMaterialDto : IMap
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public string PriceItem { get; set; }
        public string PurchasePlace { get; set; }
        public IFormFile Photo { get; set; }


        public int? LoanTrancheId { get; set; }
        public int ExecutionId { get; set; }
        public int? PaymentTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddMaterialDto, Material>()
                .ForMember(d => d.PriceItem, opt => opt.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.PriceItem)))
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => s.Photo.SaveFile()));
        }
    }
}
