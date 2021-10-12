using Application.Core;
using MediatR;

namespace Application.CosmosDocuments.Query.GetDetail
{
    public record GetCosmosDocumentByIdQuery(string id): IRequest<Response<GetCosmosDocumentDto>>
    {

    }
}
