using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using System;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentDto: IMap
    {
        public string Name { get; set; }
        public int StageId { get; set; }
        public string Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public string Description { get; set; }
        public int? SendTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? PreparationId { get; set; }
        public int? PostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDocumentDto, Domain.Entities.Document>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.Cost)));       
        }

    }
}
