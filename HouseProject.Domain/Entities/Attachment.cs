﻿using HouseProject.Domain.Common;

namespace HouseProject.Domain.Entities
{
    public class Attachment: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}