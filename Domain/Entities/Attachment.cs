using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Attachments")]
    public class Attachment: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDeleted { get; set; }

        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}
