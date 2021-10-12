using Application.Extensions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsBackup.Command.Add
{
    public class AddAttachmentBackupToApplicationHandler : IRequestHandler<AddAttachmentBackupToApplicationCommand, Unit>
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public AddAttachmentBackupToApplicationHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Unit> Handle(AddAttachmentBackupToApplicationCommand request, CancellationToken cancellationToken)
        {
            var attachmentBackup = new AttachmentBackup
            {
                ApplicationId = request.applicationId,
                File = request.formFile.GetBytes(),
                Name = request.formFile.FileName,
            };

            await _attachmentRepository.AddBackupAsync(attachmentBackup);

            return Unit.Value;
        }
    }
}
