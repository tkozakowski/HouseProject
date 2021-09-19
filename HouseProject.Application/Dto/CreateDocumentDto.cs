using Application.Conversions;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto
{
    public class CreateDocumentDto: IMap
    {
        public string Name { get; set; }
        public int StageId { get; set; }
        public string Cost { get; set; }
        public string ReceivedAt { get; set; }
        public string Description { get; set; }
        //public int SendTypeId { get; set; }
        //public int ProjectId { get; set; }
        //public int PreparationId { get; set; }
        //public int PostId { get; set; }
        //public int StageId { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Document, CreateDocumentDto>()
            //    .ForMember(d => d.SendTypeName, o => o.MapFrom(s => s.SendType.Name))
            //    .ForMember(d => d.PostTypeName, o => o.MapFrom(s => s.Post.Name))
            //    .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project.Name))
            //    .ForMember(d => d.PreparationName, o => o.MapFrom(s => s.Preparation.Name))
            //    .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => DateTimeToString.ConvertNullableDateTimeToString(s.ReceivedAt)));

            profile.CreateMap<CreateDocumentDto, Document>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => StringToDecimal.ConvertStringToDecimal(s.Cost)))
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => StringToDateTime.ConvertStringToDateTime(s.ReceivedAt)));           

        }

    }
}
