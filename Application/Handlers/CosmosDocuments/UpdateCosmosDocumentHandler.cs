using Application.Command.CosmosDocuments;
using Application.Core;
using AutoMapper;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class UpdateCosmosDocumentHandler : IRequestHandler<UpdateCosmosDocumentCommand, Response<Unit>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;
        private readonly IMapper _mapper;

        public UpdateCosmosDocumentHandler(IMapper mapper, ICosmosDocumentRepository cosmosDocumentRepository)
        {
            _mapper = mapper;
            _cosmosDocumentRepository = cosmosDocumentRepository;
        }

        public async Task<Response<Unit>> Handle(UpdateCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<CosmosDocument>(request.CosmosDocumentDto);

            if (document is null) return Response<Unit>.Failure("Failed to update document");

            await _cosmosDocumentRepository.UpdateAsync(document);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
