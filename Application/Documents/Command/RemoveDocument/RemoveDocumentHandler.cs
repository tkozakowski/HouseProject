using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Command.RemoveDocument
{
    public class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public RemoveDocumentHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _houseProjectDbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return Result<Unit>.Failure("Document doesn't exists in db");

            _houseProjectDbContext.Documents.Remove(document);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to remove document");


            var documentTotalCosts = await _houseProjectDbContext.Documents?.SumAsync(x => x.Cost);
            if (documentTotalCosts != null)
            {
                var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync(x => x.Id == 1);
                finance.DocumentsCost = documentTotalCosts;

                await _houseProjectDbContext.SaveChangesAsync();
            }


            return Result<Unit>.Success(Unit.Value);
        }
    }
}
