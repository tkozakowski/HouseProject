using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddAttachmentDto : IMap
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attachment, AddAttachmentDto>();
        }
    }
}
