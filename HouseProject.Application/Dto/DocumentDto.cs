using AutoMapper;
using Application.Mappings;
using Domain.Entities;
using Application.Conversions;
using System;

namespace Application.Dto
{
    public class DocumentDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public string Description { get; set; }
        public string SendTypeName { get; set; }
        public string PostTypeName { get; set; }
        public string ProjectName { get; set; }
        public string PreparationName { get; set; }
        public string StageName { get; set; }
        public DateTime CreationDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentDto>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => DecimalToString.ConvertNullableDecimalToString(s.Cost)))
                .ForMember(d => d.SendTypeName, o => o.MapFrom(s => s.SendType.Name))
                .ForMember(d => d.PostTypeName, o => o.MapFrom(s => s.Post.Name))
                .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project.Name))
                .ForMember(d => d.PreparationName, o => o.MapFrom(s => s.Preparation.Name))
                .ForMember(d => d.StageName, o => o.MapFrom(s => s.Stage.Name))
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreatedAt));

            profile.CreateMap<DocumentDto, Document>()
                .ForMember(d => d.SendType, o => o.MapFrom(s => new SendType { Name = s.Name }))
                .ForMember(d => d.Post, o => o.MapFrom(s => new Post { Name = s.Name }))
                .ForMember(d => d.Project, o => o.MapFrom(s => new Project { Name = s.Name }))
                .ForMember(d => d.StageId, o => o.NullSubstitute(3));
        }

    }
}
