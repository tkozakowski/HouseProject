using HouseProject.Domain.Common;
using HouseProject.Domain.Enum;
using System;
using System.Collections.Generic;

namespace HouseProject.Domain.Entities
{
    public class Preparation: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public decimal? Advance { get; set; }
        public Payment Payment { get; set; }
        public DateTime? ExecutedAt { get; set; }

        public ICollection<Document> Documents { get; set; }

    }
}
