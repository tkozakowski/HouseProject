using Application.Core;
using Application.Dto.Cosmos;
using MediatR;

namespace Application.Queries.CosmosDocuments
{
    public class GetCosmosDocumentByIdQuery: IRequest<Result<CosmosDocumentDto>>
    {
        public string Id { get; set; }
    }
}
