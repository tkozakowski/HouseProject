using Application.Conversions;
using Application.Extensions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Materials.Command.Add
{
    public class AddMaterialDto : IMap
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public string PriceItem { get; set; }
        public string PurchasePlace { get; set; }

        public int? LoanTrancheId { get; set; }
        public int ExecutionId { get; set; }
        public int? PaymentTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddMaterialDto, Material>()
                .ForMember(d => d.PriceItem, opt => opt.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.PriceItem)));
        }
    }
}
