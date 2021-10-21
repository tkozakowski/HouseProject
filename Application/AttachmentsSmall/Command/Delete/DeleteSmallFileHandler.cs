using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Command.DeleteFromDb
{
    public class DeleteSmallFileHandler : IRequestHandler<DeleteSmallFileCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DeleteSmallFileHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<Unit>> Handle(DeleteSmallFileCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.AttachmentsBackup.FirstOrDefaultAsync(x => x.Id == request.AttachmentId);

            if (attachment is null) return Response<Unit>.Failure("Failed to remove attachment");

            _houseProjectDbContext.AttachmentsBackup.Remove(attachment);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to remove file");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
