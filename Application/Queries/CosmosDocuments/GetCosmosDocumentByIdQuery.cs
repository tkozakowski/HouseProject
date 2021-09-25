using Application.Core;
using Application.Dto.Cosmos;
using MediatR;

namespace Application.Queries.CosmosDocuments
{
    public class GetCosmosDocumentByIdQuery: IRequest<Response<CosmosDocumentDto>>
    {
        public string Id { get; set; }
    }
}
