using Application.Command.Attachment;
using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class DeleteFileByIdHandler : IRequestHandler<DeleteFileByIdCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DeleteFileByIdHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Response<Unit>> Handle(DeleteFileByIdCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == request.attachmentId);

            if (attachment is null) return Response<Unit>.Failure("Failed to remove attachment");

            _houseProjectDbContext.Attachments.Remove(attachment);

            await _houseProjectDbContext.SaveChangesAsync();

            File.Delete(attachment.Path);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
