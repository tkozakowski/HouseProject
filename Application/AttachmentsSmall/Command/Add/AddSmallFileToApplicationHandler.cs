using Application.Core;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Command.Add
{
    public class AddSmallFileToApplicationHandler : IRequestHandler<AdSmallFileToApplicationCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddSmallFileToApplicationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<Unit>> Handle(AdSmallFileToApplicationCommand request, CancellationToken cancellationToken)
        {
            var attachmentBackup = new AttachmentBackup
            {
                ApplicationId = request.ApplicationId,
                File = request.FormFile.GetBytes(),
                Name = request.FormFile.FileName,
            };

            _houseProjectDbContext.AttachmentsBackup.Add(attachmentBackup);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;          

            if (!success) return Response<Unit>.Failure("Failed to add attachment to backup");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
