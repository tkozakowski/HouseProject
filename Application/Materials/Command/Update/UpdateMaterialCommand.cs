using Application.Conversions;
using Application.Core;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Materials.Command.Update
{
    public class UpdateMaterialCommand: IRequest<Result<Unit>>, IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public string PriceItem { get; set; }
        public string PurchasePlace { get; set; }
        public string Photo { get; set; }
        public int? LoanTrancheId { get; set; }
        public int? ExecutionId { get; set; }
        public int? PaymentTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMaterialCommand, Material>()
                .ForMember(d => d.PriceItem, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.PriceItem)));
        }
    }
}
