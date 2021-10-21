using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.AttachmentsSmall.Query.GetAll
{
    public class SmallFileDetailDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AttachmentBackup, SmallFileDetailDto>();
        }
    }
}
