using Application.Command.CosmosDocuments;
using Application.Core;
using Application.Dto.Cosmos;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class InsertCosmosDocumentHandler : IRequestHandler<InsertCosmosDocumentCommand, Response<Unit>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;
        private readonly IMapper _mapper;

        public InsertCosmosDocumentHandler(IMapper mapper, ICosmosDocumentRepository cosmosDocumentRepository)
        {
            _mapper = mapper;
            _cosmosDocumentRepository = cosmosDocumentRepository;
        }

        public async Task<Response<Unit>> Handle(InsertCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var cosmosDocument = _mapper.Map<CosmosDocument>(request.cosmosDocument);
            
            await _cosmosDocumentRepository.AddAsync(cosmosDocument); 

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
