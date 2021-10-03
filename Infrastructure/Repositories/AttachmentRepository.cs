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
        public async Task<IEnumerable<Attachment>> GetAll()
        {
            return await _houseProjectDbContext.Attachments.ToListAsync();
        }

        public async Task AddBackupAsync(AttachmentBackup attachment)
        {
            _houseProjectDbContext.AttachmentsBackup.Add(attachment);

            await _houseProjectDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Attachment>> GetAttachmentsByApplicationId(int applicationId)
        {
            return await _houseProjectDbContext.Attachments.Where(x => x.ApplicationId == applicationId).ToListAsync();
        }

        public async Task<IEnumerable<AttachmentBackup>> GetAttachmentsBackupByApplicationId(int applicationId)
        {
            return await _houseProjectDbContext.AttachmentsBackup.Where(x => x.ApplicationId == applicationId).ToListAsync();
        }

    }
}
