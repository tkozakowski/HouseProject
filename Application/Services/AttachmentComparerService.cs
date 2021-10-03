using Application.Command.Attachment;
using Application.Conversions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AttachmentComparerService : IAttachmentService
    {
        private readonly IMediator _mediator;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly ILogger _logger;

        public AttachmentComparerService(IMediator mediator, ILogger<AttachmentComparerService> logger, IAttachmentRepository attachmentRepository)
        {
            _mediator = mediator;
            _attachmentRepository = attachmentRepository;
            _logger = logger;
        }
        public async Task RecoverFiles()
        {
            List<Domain.Entities.Application> applications = await _houseProjectDbContext.Applications.ToListAsync();

            if (applications is null) return;

            foreach (var application in applications)
            {
                var attachments = await _attachmentRepository.GetAttachmentsByApplicationId(application.Id);
                if (attachments is null) break;

                var attachmentsBackup = await _attachmentRepository.GetAttachmentsBackupByApplicationId(application.Id);
                if (attachmentsBackup is null) break;

                if (attachmentsBackup.Count == attachments.Count) break;

                if (attachmentsBackup.Count > attachments.Count)
                {
                    var diffs = attachmentsBackup.Where(ab => !attachments.Any(a => a.Name == ab.Name));
                    foreach (var diff in diffs)
                    {
                        _logger.LogDebug($"Recover {diff} file");

                        await _mediator.Send(new AddAttachmentToApplicationCommand(
                            diff.ApplicationId.Value, ByteArrayToIFormFile.ConvertByteArrayToIFormFile(diff.File, diff.Name)));
                    }
                }
            }

            await Task.CompletedTask;
        }

    }
}
