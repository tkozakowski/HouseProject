using Application.Core;
using Application.Interfaces;
using Cosmonaut.Extensions;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.DeleteFromHD
{
    public class DeleteFileHandler : IRequestHandler<DeleteFileCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DeleteFileHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == request.AttachmentId);

            attachment.IsDeleted = true;
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to remove file");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
