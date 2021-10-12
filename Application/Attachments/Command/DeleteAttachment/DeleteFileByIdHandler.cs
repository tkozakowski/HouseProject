using Application.Core;
using Domain.Interfaces;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.DeleteAttachment
{
    public class DeleteFileByIdHandler : IRequestHandler<DeleteFileByIdCommand, Response<Unit>>
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public DeleteFileByIdHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Response<Unit>> Handle(DeleteFileByIdCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(request.AttachmentId);

            if (attachment is null) return Response<Unit>.Failure("Failed to remove attachment");

            await _attachmentRepository.DeleteAsync(attachment);

            File.Delete(attachment.Path);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
