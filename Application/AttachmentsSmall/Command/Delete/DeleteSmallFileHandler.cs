using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Command.DeleteFromDb
{
    public class DeleteSmallFileHandler : IRequestHandler<DeleteSmallFileCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DeleteSmallFileHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(DeleteSmallFileCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.AttachmentsBackup
                .FirstOrDefaultAsync(x => x.Id == request.AttachmentId);

            if (attachment is null) return Result<Unit>.Failure("Failed to remove attachment");

            attachment.IsDeleted = true;
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to remove file");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
