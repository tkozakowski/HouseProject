using Application.Command.CosmosDocuments;
using Application.Core;
using Application.Dto.Cosmos;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class UpdateCosmosDocumentHandler : IRequestHandler<UpdateCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public UpdateCosmosDocumentHandler(ICosmosStore<CosmosDocument> cosmosStore, IMapper mapper)
        {
            _cosmosStore = cosmosStore;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingDocument = await _cosmosStore.FindAsync(request.CosmosDocumentDto.Id);

            if (existingDocument is null) return Result<Unit>.Failure("Failed to update document");

            await _cosmosStore.UpdateAsync(existingDocument);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
