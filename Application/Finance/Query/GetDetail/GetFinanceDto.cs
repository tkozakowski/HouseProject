using Application.Mappings;
using AutoMapper;

namespace Application.Finance.Query.GetDetail
{
    public class GetFinanceDto: IMap
    {
        public int Id { get; set; }
        public decimal? ProjectsCost { get; set; }
        public decimal? PreparationsCost { get; set; }
        public decimal? DocumentsCost { get; set; }
        public decimal? ExecutionsCost { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Finance, GetFinanceDto>();
        }
    }
}
