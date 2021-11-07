using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public UpdateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseProjectDbContext)
        {
            _mapper = mapper;
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingDocument = await _houseProjectDbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existingDocument is null) return null;

            _mapper.Map(request.UpdateDocumentDto, existingDocument);
            existingDocument.UserId = request.UserId;

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to update document");

            var documentTotalCosts = await _houseProjectDbContext.Documents.SumAsync(x => x.Cost);
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
