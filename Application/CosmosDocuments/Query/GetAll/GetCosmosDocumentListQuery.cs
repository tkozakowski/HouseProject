using Application.Core;
using Application.CosmosDocuments.Query.GetAll;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.CosmosDocuments
{
    public record GetCosmosDocumentListQuery : IRequest<Result<List<CosmosDocumentDto>>>;

}
