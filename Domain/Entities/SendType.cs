using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("SendTypes")]
    public class SendType: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<SendApplication> Applications { get; set; }
    }
}
