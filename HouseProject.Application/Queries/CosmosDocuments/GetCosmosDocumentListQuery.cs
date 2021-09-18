using Application.Core;
using Domain.Entities.Cosmos;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.CosmosDocuments
{
    public record GetCosmosDocumentListQuery : IRequest<Result<List<CosmosDocument>>>;

}
