using Application.Core;
using Application.Queries.CosmosDocuments;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Query.GetAll
{
    public class GetCosmosDocumentListHandler : IRequestHandler<GetCosmosDocumentListQuery, Response<List<CosmosDocumentDto>>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;
        private readonly IMapper _mapper;

        public GetCosmosDocumentListHandler(IMapper mapper, ICosmosDocumentRepository cosmosDocumentRepository)
        {
            _mapper = mapper;
            _cosmosDocumentRepository = cosmosDocumentRepository;
        }
        public async Task<Response<List<CosmosDocumentDto>>> Handle(GetCosmosDocumentListQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocuments = await _cosmosDocumentRepository.GetAllAsync();
            var cosmosDocumentsDto = _mapper.Map<List<CosmosDocumentDto>>(cosmosDocuments);

            return Response<List<CosmosDocumentDto>>.Success(cosmosDocumentsDto);
        }
    }
}
