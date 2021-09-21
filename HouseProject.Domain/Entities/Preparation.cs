using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Preparation: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public decimal? Advance { get; set; }
        public DateTime? ExecutedAt { get; set; }

        public int? PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public ICollection<Document> Documents { get; set; }

    }
}
