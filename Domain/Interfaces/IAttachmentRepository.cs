using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAttachmentRepository
    {
        public Task<IEnumerable<Attachment>> GetAll();
        public Task AddBackupAsync(AttachmentBackup attachment);
        Task<List<Attachment>> GetAttachmentsByApplicationId(int applicationId);
        Task<List<AttachmentBackup>> GetAttachmentsBackupByApplicationId(int applicationId);
    }
}
