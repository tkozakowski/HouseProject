using Application.Core;
using Application.Dto.Cosmos;
using Application.Queries.CosmosDocuments;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class GetCosmosDocumentByIdHandler : IRequestHandler<GetCosmosDocumentByIdQuery, Response<CosmosDocumentDto>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;
        private readonly IMapper _mapper;

        public GetCosmosDocumentByIdHandler(ICosmosDocumentRepository cosmosDocumentRepository, IMapper mapper)
        {
            _cosmosDocumentRepository = cosmosDocumentRepository;
            _mapper = mapper;
        }

        public async Task<Response<CosmosDocumentDto>> Handle(GetCosmosDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocument = await _cosmosDocumentRepository.GetByIdAsync(request.Id);
            var cosmosDocumentDto = _mapper.Map<CosmosDocumentDto>(cosmosDocument);

            return Response<CosmosDocumentDto>.Success(cosmosDocumentDto);
        }
    }
}
