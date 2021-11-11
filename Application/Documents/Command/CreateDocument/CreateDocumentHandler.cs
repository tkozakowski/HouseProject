using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Finance.Command.UpdateByDocument;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IHouseProjectDbContext _houseDbContext;
        private readonly IMediator _mediator;

        public CreateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseDbContext, IMediator mediator)
        {
            _mapper = mapper;
            _houseDbContext = houseDbContext;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Domain.Entities.Document>(request.CreateDocumentDto);

            document.UserId = request.UserId;

            _houseDbContext.Documents.Add(document);

            var success = await _houseDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Send(new UpdateFinanceByDocumentCommand());

                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to create document");
        }
    }
}
