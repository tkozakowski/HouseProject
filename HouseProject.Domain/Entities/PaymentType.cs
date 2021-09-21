using System.Collections.Generic;

namespace Domain.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Preparation> Preparations { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
