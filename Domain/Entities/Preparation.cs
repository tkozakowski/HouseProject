using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Preparations")]
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

        public int FinanceId { get; set; }
        public virtual Finance Finance { get; set; }

        public ICollection<Document> Documents { get; set; }

    }
}
