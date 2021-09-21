using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Materials
{
    public class GetMaterialsDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal? PriceItem { get; set; }
        public string PurchasePlace { get; set; }
        public string Payment { get; set; }
        public string Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, GetMaterialsDto>()
                .ForMember(d => d.Payment, o => o.MapFrom(s => s.PaymentType.Name));               
        }
    }
}
