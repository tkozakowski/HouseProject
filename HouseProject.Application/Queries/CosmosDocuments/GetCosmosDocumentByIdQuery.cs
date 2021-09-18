using Application.Core;
using Domain.Entities.Cosmos;
using MediatR;

namespace Application.Queries.CosmosDocuments
{
    public class GetCosmosDocumentByIdQuery: IRequest<Result<CosmosDocument>>
    {
        public string Id { get; set; }
    }
}
