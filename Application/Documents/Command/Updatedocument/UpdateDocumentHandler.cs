using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Finance.Command.UpdateByDocument;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseProjectDbContext, IMediator mediator)
        {
            _mapper = mapper;
            _houseProjectDbContext = houseProjectDbContext;
            _mediator = mediator;
        }
        public async Task<Result<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingDocument = await _houseProjectDbContext.Documents?.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existingDocument is null) return null;

            _mapper.Map(request.UpdateDocumentDto, existingDocument);
            existingDocument.UserId = request.UserId;

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Send(new UpdateFinanceByDocumentCommand());

                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to update document");
        }
    }
}
