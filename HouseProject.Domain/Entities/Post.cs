using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Posts")]
    public class Post: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
