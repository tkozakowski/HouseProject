using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.AttachmentsSmall.Query.GetAll
{
    public record GetSmallFilesByApplicationQuery(int applicationId) : IRequest<Response<IEnumerable<SmallFileDetailDto>>>
    {
    }
}
