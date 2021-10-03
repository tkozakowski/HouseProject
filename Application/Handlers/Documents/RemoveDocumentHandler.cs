using Application.Command.Documents;
using Application.Core;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Documents
{
    class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Response<Unit>>
    {
        private readonly IDocumentRepository _documentRepository;

        public RemoveDocumentHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Response<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetByIdAsync(request.Id);

            await _documentRepository.RemoveAsync(document);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
