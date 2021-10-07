using AutoMapper;
using Application.Command.Documents;
using Application.Core;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Handlers.Documents
{
    public class InsertDocumentHandler : IRequestHandler<InsertDocumentCommand, Response<Unit>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public InsertDocumentHandler(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }
        public InsertDocumentHandler() {}

        public async Task<Response<Unit>> Handle(InsertDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Document>(request.CreateDocumentDto);

            document.UserId = request.UserId;

            var success = await _documentRepository.AddAsync(document);

            if (success) return Response<Unit>.Success(Unit.Value);

            return Response<Unit>.Failure("Failed to create document");
        }
    }
}
