using Application.Core;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Command.Remove
{
    public class RemoveCosmosDocumentHandler : IRequestHandler<RemoveCosmosDocumentCommand, Response<Unit>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;

        public RemoveCosmosDocumentHandler(ICosmosDocumentRepository cosmosDocumentRepository)
        {
            _cosmosDocumentRepository = cosmosDocumentRepository;
        }

        public async Task<Response<Unit>> Handle(RemoveCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var cosmosDocument = await _cosmosDocumentRepository.GetByIdAsync(request.Id);

            if (cosmosDocument is null) return null;

            await _cosmosDocumentRepository.RemoveAsync(cosmosDocument);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
