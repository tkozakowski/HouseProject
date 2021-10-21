using Application.Core;
using Application.Interfaces;
using Cosmonaut.Extensions;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.DeleteFromHD
{
    public class DeleteFileFromHDHandler : IRequestHandler<DeleteFileFromHDCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DeleteFileFromHDHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<Unit>> Handle(DeleteFileFromHDCommand request, CancellationToken cancellationToken)
        {
            var path = (await _houseProjectDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == request.AttachmentId)).Path;

            if (string.IsNullOrEmpty(path)) return null;

            File.Delete(path);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
