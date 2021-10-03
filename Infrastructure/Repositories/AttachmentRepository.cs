using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public AttachmentRepository(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return await _houseProjectDbContext.Attachments.ToListAsync();
        }

        public async Task<Attachment> GetByIdAsync(int id)
        {
            return await _houseProjectDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> AddAsync(Attachment attachment)
        {
            _houseProjectDbContext.Attachments.Add(attachment);

            return await _houseProjectDbContext.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(Attachment attachment)
        {
            _houseProjectDbContext.Attachments.Remove(attachment);

            await _houseProjectDbContext.SaveChangesAsync();
        }
        public async Task AddBackupAsync(AttachmentBackup attachment)
        {
            _houseProjectDbContext.AttachmentsBackup.Add(attachment);

            await _houseProjectDbContext.SaveChangesAsync();
        }

        public async Task<List<Attachment>> GetAttachmentsByApplicationIdAsync(int applicationId)
        {
            return await _houseProjectDbContext.Attachments.Where(x => x.ApplicationId == applicationId).ToListAsync();
        }

        public async Task<List<AttachmentBackup>> GetAttachmentsBackupByApplicationIdAsync(int applicationId)
        {
            return await _houseProjectDbContext.AttachmentsBackup.Where(x => x.ApplicationId == applicationId).ToListAsync();
        }

    }
}
