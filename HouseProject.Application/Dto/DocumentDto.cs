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
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentDto>();
        }
    }
}
