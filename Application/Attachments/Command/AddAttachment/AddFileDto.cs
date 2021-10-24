using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddFileDto : IMap
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attachment, AddFileDto>();
        }
    }
}
