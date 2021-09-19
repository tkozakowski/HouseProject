using AutoMapper;
using Application.Mappings;
using Domain.Entities;
using Application.Conversions;

namespace Application.Dto
{
    public class DocumentDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public decimal Cost { get; set; }
        public string ReceivedAt { get; set; }
        public string Description { get; set; }
        public string SendTypeName { get; set; }
        public string PostTypeName { get; set; }
        public string ProjectName { get; set; }
        public string PreparationName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentDto>()
                .ForMember(d => d.SendTypeName, o => o.MapFrom(s => s.SendType.Name))
                .ForMember(d => d.PostTypeName, o => o.MapFrom(s => s.Post.Name))
                .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project.Name))
                .ForMember(d => d.PreparationName, o => o.MapFrom(s => s.Preparation.Name))
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => DateTimeToString.ConvertNullableDateTimeToString(s.ReceivedAt)));

            profile.CreateMap<DocumentDto, Document>()
                .ForMember(d => d.SendType, o => o.MapFrom(s => new SendType { Name = s.Name }))
                .ForMember(d => d.Post, o => o.MapFrom(s => new Post { Name = s.Name }))
                .ForMember(d => d.Project, o => o.MapFrom(s => new Project { Name = s.Name }))
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => StringToDateTime.ConvertStringToDateTime(s.ReceivedAt)))
                .ForMember(d => d.StageId, o => o.NullSubstitute(3));
        }

    }
}
