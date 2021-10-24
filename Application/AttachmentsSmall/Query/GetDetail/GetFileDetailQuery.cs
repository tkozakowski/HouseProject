using Application.Core;
using MediatR;

namespace Application.AttachmentsSmall.Query.GetDetail
{
    public record GetFileDetailQuery(int fileId): IRequest<Response<GetFileDetailDto>>
    {
    }
}
