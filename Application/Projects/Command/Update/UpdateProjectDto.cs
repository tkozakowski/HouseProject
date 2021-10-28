using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Projects.Command.Update
{
    public class UpdateProjectDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int? PaymentTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, Project>();
        }
    }
}
