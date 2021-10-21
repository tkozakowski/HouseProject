using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Command.RemoveDocument
{
    public class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public RemoveDocumentHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _houseProjectDbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return Response<Unit>.Failure("Document doesn't exists in db");

            _houseProjectDbContext.Documents.Remove(document);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to remove document");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
