using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.AttachmentsDb.Query.Get
{
    public record GetSmallFileQuery(int applicationId) : IRequest<Response<IEnumerable<SmallFileDetailDto>>>
    {
    }
}
