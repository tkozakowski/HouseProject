using Application.Command.Attachment;
using Application.Conversions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AttachmentComparerService : IAttachmentComparerService
    {
        private readonly IMediator _mediator;
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AttachmentComparerService(IMediator mediator, IHouseProjectDbContext houseProjectDbContext)
        {
            _mediator = mediator;
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task RecoverFiles()
        {
            List<Domain.Entities.Application> applications = await _houseProjectDbContext.Applications.ToListAsync();

            if (applications is null) return;

            foreach (var application in applications)
            {
                var attachments = await GetAttachmentsByApplicationId(application.Id);
                if (attachments is null) break;

                var attachmentsBackup = await GetAttachmentsBackupByApplicationId(application.Id);
                if (attachmentsBackup is null) break;

                if (attachmentsBackup.Count == attachments.Count) break;

                if (attachmentsBackup.Count > attachments.Count)
                {
                    var diffs = attachmentsBackup.Where(ab => !attachments.Any(a => a.Name == ab.Name));
                    foreach (var diff in diffs)
                    {
                        await _mediator.Send(new AddAttachmentToApplicationCommand(
                            diff.ApplicationId.Value, ByteArrayToIFormFile.ConvertByteArrayToIFormFile(diff.File, diff.Name)));
                    }
                }
            }

            await Task.CompletedTask;
        }

        public async Task<List<Attachment>> GetAttachmentsByApplicationId(int id)
        {
            return await _houseProjectDbContext.Attachments.Where(x => x.ApplicationId == id).ToListAsync();
        }
        public async Task<List<AttachmentBackup>> GetAttachmentsBackupByApplicationId(int id)
        {
            return await _houseProjectDbContext.AttachmentsBackup.Where(x => x.ApplicationId == id).ToListAsync();
        }

    }
}
