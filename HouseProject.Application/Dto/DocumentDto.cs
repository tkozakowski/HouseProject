using AutoMapper;
using HouseProject.Application.Mappings;
using HouseProject.Domain.Entities;
using System;

namespace HouseProject.Application.Dto
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
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => ConvertNullableDateTimeToString(s.ReceivedAt)));
        }

        private static string ConvertNullableDateTimeToString(DateTime? receivedAt)
        {
            if (receivedAt is null) return String.Empty;
            return receivedAt.ToString();
        }
    }
}
