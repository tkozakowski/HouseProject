using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IHouseProjectDbContext _houseDbContext;

        public CreateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseDbContext)
        {
            _mapper = mapper;
            _houseDbContext = houseDbContext;
        }
        public CreateDocumentHandler() { }

        public async Task<Result<Unit>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Domain.Entities.Document>(request.CreateDocumentDto);

            document.UserId = request.UserId;

            _houseDbContext.Documents.Add(document);

            var success = await _houseDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to create document");

            var documentTotalCosts = await _houseDbContext.Documents.SumAsync(x => x.Cost);
            if (documentTotalCosts != null)
            {
                var finance = await _houseDbContext.Finances.FirstOrDefaultAsync(x => x.Id == 1);
                finance.DocumentsCost = documentTotalCosts;

                await _houseDbContext.SaveChangesAsync();
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
