using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, Response<Unit>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public CreateDocumentHandler(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }
        public CreateDocumentHandler() {}

        public async Task<Response<Unit>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Domain.Entities.Document>(request.CreateDocumentDto);

            document.UserId = request.UserId;

            var success = await _documentRepository.AddAsync(document);

            if (success) return Response<Unit>.Success(Unit.Value);

            return Response<Unit>.Failure("Failed to create document");
        }
    }
}
