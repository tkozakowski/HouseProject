using Application.Core;
using MediatR;

namespace Application.AttachmentsSmall.Query.GetDetail
{
    public record GetFileDetailCommand(int fileId): IRequest<Response<GetFileDetailDto>>
    {
    }
}
