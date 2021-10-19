using Application.Core;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Command.RemoveDocument
{
    public class RemoveDocumentHandler : IRequestHandler<RemoveDocumentCommand, Response<Unit>>
    {
        private readonly IDocumentRepository _documentRepository;

        public RemoveDocumentHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Response<Unit>> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            await _documentRepository.RemoveAsync(request.Id);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
