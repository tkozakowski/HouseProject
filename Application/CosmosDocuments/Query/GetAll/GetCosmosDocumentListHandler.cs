using Application.Core;
using Application.Queries.CosmosDocuments;
using AutoMapper;
using Cosmonaut;
using Cosmonaut.Extensions;
using Domain.Entities.Cosmos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Query.GetAll
{
    public class GetCosmosDocumentListHandler : IRequestHandler<GetCosmosDocumentListQuery, Response<List<CosmosDocumentDto>>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public GetCosmosDocumentListHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<List<CosmosDocumentDto>>> Handle(GetCosmosDocumentListQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocuments = await _cosmosStore.Query().ToListAsync();
            var cosmosDocumentsDto = _mapper.Map<List<CosmosDocumentDto>>(cosmosDocuments);

            return Response<List<CosmosDocumentDto>>.Success(cosmosDocumentsDto);
        }
    }
}
