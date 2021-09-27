using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.AttachmentsBackup
{
    public class AttachmentBackupsInfoDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AttachmentBackup, AttachmentBackupsInfoDto>();
        }
    }
}
