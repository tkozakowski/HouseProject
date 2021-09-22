using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PaymentTypes")]
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Preparation> Preparations { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
