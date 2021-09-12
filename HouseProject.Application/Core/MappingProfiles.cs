using AutoMapper;
using HouseProject.Application.Dto;
using HouseProject.Domain.Entities;

namespace HouseProject.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();
        }
    }
}
