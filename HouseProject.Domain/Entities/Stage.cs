using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Stages")]
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
