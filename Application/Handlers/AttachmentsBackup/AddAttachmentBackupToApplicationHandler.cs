using Application.Command.AttachmentBackup;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.AttachmentsBackup
{
    public class AddAttachmentBackupToApplicationHandler : IRequestHandler<AddAttachmentBackupToApplicationCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddAttachmentBackupToApplicationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Unit> Handle(AddAttachmentBackupToApplicationCommand request, CancellationToken cancellationToken)
        {
            var attachmentBackup = new AttachmentBackup
            {
                ApplicationId = request.applicationId,
                File = request.formFile.GetBytes(),
                Name = request.formFile.FileName,
            };

            _houseProjectDbContext.AttachmentsBackup.Add(attachmentBackup);

            await _houseProjectDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
