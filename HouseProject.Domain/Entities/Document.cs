using HouseProject.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseProject.Domain.Entities
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Project))]
        public int Project_Fk { get; set; }


        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public Payment Payment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReceivedAt { get; set; }

        public virtual Project Project { get; set; }
    }
}
