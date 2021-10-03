using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAttachmentRepository
    {
        public Task<IEnumerable<Attachment>> GetAllAsync();
        public Task<Attachment> GetByIdAsync(int id);
        public Task<bool> AddAsync(Attachment attachment);
        public Task DeleteAsync(Attachment attachment);
        public Task AddBackupAsync(AttachmentBackup attachment);
        public Task<List<Attachment>> GetAttachmentsByApplicationIdAsync(int applicationId);
        public Task<List<AttachmentBackup>> GetAttachmentsBackupByApplicationIdAsync(int applicationId);
    }
}
