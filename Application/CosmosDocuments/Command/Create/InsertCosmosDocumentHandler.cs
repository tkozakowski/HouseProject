using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Command.Create
{
    public class InsertCosmosDocumentHandler : IRequestHandler<InsertCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public InsertCosmosDocumentHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(InsertCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var cosmosDocument = _mapper.Map<CosmosDocument>(request.CosmosDocument);

            cosmosDocument.Id = Guid.NewGuid().ToString();

            await _cosmosStore.AddAsync(cosmosDocument);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
