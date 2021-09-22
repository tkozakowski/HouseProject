using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Applications")]
    public class Application: AuditableEntity
    {
        public int Id { get; set; }
        public DateTime? SendAt { get; set; }
        public string SendBy { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? SendTypeId { get; set; }
        public virtual SendType SendType { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

    }
}
