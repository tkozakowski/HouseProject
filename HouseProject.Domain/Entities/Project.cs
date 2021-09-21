using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Project: AuditableEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }

        public int? PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
