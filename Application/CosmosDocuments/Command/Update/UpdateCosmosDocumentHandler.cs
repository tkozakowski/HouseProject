using Application.Core;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Command.Update
{
    public class UpdateCosmosDocumentHandler : IRequestHandler<UpdateCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public UpdateCosmosDocumentHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<CosmosDocument>(request.UpdateCosmosDocumentDto);

            if (document is null) return Result<Unit>.Failure("Failed to update document");

            await _cosmosStore.UpdateAsync(document);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
