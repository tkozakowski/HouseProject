using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, Response<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IHouseProjectDbContext _houseDbContext;

        public CreateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseDbContext)
        {
            _mapper = mapper;
            _houseDbContext = houseDbContext;
        }
        public CreateDocumentHandler() {}

        public async Task<Response<Unit>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Domain.Entities.Document>(request.CreateDocumentDto);

            document.UserId = request.UserId;

            _houseDbContext.Documents.Add(document);

            var success = await _houseDbContext.SaveChangesAsync() > 0;

            if (success) return Response<Unit>.Success(Unit.Value);

            return Response<Unit>.Failure("Failed to create document");
        }
    }
}
