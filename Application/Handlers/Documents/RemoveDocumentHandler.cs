using Application.Command.Documents;
using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Documents
{
    class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _context;

        public RemoveDocumentHandler(IHouseProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Response<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return null;

            _context.Documents.Remove(document);

            var success = await _context.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to remove document");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
