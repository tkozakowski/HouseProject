//using Application.Attachments.Command.AddAttachment;
//using Application.Conversions;
//using Application.Interfaces;
//using Domain.Interfaces;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Application.Services
//{
//    public class AttachmentComparerService : IAttachmentService
//    {
//        private readonly IMediator _mediator;
//        private readonly IHouseProjectDbContext _houseProjectDbContext;
//        private readonly ILogger _logger;

//        public AttachmentComparerService(IMediator mediator, IHouseProjectDbContext houseProjectDbContext, ILogger logger)
//        {
//            _mediator = mediator;
//            _houseProjectDbContext = houseProjectDbContext;
//            _logger = logger;
//        }

//        public async Task RecoverFiles()
//        {
//            List<Domain.Entities.SendApplication> applications = await _houseProjectDbContext.SendApplications.ToListAsync();

//            if (applications is null) return;

//            foreach (var application in applications)
//            {
//                var attachments = await _attachmentRepository.GetAttachmentsByApplicationIdAsync(application.Id);
//                if (attachments is null) break;

//                var attachmentsBackup = await _attachmentRepository.GetAttachmentsBackupByApplicationIdAsync(application.Id);
//                if (attachmentsBackup is null) break;

//                if (attachmentsBackup.Count == attachments.Count) break;

//                if (attachmentsBackup.Count > attachments.Count)
//                {
//                    var diffs = attachmentsBackup.Where(ab => !attachments.Any(a => a.Name == ab.Name));
//                    foreach (var diff in diffs)
//                    {
//                        _logger.LogDebug($"Recover {diff} file");

//                        await _mediator.Send(new AddAttachmentToApplicationCommand { ApplicationId = diff.ApplicationId.Value, File = ByteArrayToIFormFile.ConvertByteArrayToIFormFile(diff.File, diff.Name) });
//                    }
//                }
//            }

//            await Task.CompletedTask;
//        }

//    }
//}
