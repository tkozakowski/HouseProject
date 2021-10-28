using Application.Core;
using Application.Documents.Query.GetDocumentDetails;
using MediatR;

namespace Application.Documents.Query.Details
{
    public record GetDocumentDetailQuery(int id) : IRequest<Result<DocumentDetailsDto>>;

}
