using Application.Command.CosmosDocuments;
using Application.Core;
using Application.Dto.Cosmos;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class InsertCosmosDocumentHandler : IRequestHandler<InsertCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public InsertCosmosDocumentHandler(IMapper mapper, ICosmosStore<CosmosDocument> cosmosStore)
        {
            _mapper = mapper;
            _cosmosStore = cosmosStore;
        }

        public async Task<Result<Unit>> Handle(InsertCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var cosmosDocument = _mapper.Map<CosmosDocument>(request.cosmosDocument);
            cosmosDocument.Id = Guid.NewGuid().ToString();
            await _cosmosStore.AddAsync(cosmosDocument);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
