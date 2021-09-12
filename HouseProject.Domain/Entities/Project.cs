using HouseProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseProject.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Stage { get; set; }

        [MaxLength(250)]
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public Payment Payment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReceivedAt { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
