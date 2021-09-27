using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAttachmentComparerService
    {
        public Task RecoverFiles();
        Task<List<Attachment>> GetAttachmentsByApplicationId(int applicationId);
        Task<List<AttachmentBackup>> GetAttachmentsBackupByApplicationId(int applicationId);
    }
}
