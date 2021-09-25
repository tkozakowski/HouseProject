using Application.Core;
using Application.Dto.Cosmos;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.CosmosDocuments
{
    public record GetCosmosDocumentListQuery : IRequest<Response<List<CosmosDocumentDto>>>;

}
