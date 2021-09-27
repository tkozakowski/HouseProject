using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("AttachmentsBackup")]
    public class AttachmentBackup : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }

        public int? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
