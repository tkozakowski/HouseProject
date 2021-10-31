using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.PaymentTypes.Query.GetAll
{
    public class PaymentTypeDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentType, PaymentTypeDto>();
        }
    }
}
