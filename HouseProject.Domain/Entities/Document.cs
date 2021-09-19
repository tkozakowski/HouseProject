using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Document: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }
        
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
    }
}
