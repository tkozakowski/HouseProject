﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Documents")]
    public class Document: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }

        public int? SendTypeId { get; set; }
        public SendType SendType { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int? PreparationId { get; set; }
        public virtual Preparation Preparation { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? StageId { get; set; }
        public virtual Stage Stage { get; set; }

        public int? FinanceId { get; set; }
        public virtual Finance Finance { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<AttachmentSmall> AttachmentSmall { get; set; }
    }
}
