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

        public int? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
