using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectDto: IMap
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int? PaymentTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, Project>();
        }
    }
}
