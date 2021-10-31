using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("AttachmentsBackup")]
    public class AttachmentSmall : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public bool IsDeleted { get; set; }

        public int? ApplicationId { get; set; }
        public virtual SendApplication Application { get; set; }
    }
}
