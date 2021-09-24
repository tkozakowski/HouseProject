using Application.Command.Documents;
using Application.Core;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Documents
{
    class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Result<Unit>>
    {
        private readonly HouseProjectDbContext _context;

        public RemoveDocumentHandler(HouseProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return null;

            _context.Documents.Remove(document);

            var success = await _context.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to remove document");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
