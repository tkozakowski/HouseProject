using Application.Core;
using AutoMapper;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Command.Create
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
            var cosmosDocument = _mapper.Map<CosmosDocument>(request.CosmosDocument);
            
            await _cosmosDocumentRepository.AddAsync(cosmosDocument); 

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
