using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.AttachmentsSmall.Query.GetAll
{
    public record GetSmallFilesQuery(int documentId) : IRequest<Result<IEnumerable<SmallFileDetailDto>>>
    {
    }
}
