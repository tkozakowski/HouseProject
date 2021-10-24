﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public class GetApplicatedAttachmentsDto : IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attachment, GetApplicatedAttachmentsDto>();
        }
    }
}
