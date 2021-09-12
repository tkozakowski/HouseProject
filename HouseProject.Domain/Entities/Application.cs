using HouseProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseProject.Domain.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public Payment Payment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReceivedAt { get; set; }

    }
}
