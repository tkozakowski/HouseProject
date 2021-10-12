using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.Documents.Query.GetDocumentDetails;

namespace Application.Documents.Query.Details
{
    public class GetDocumentDetailHandler : IRequestHandler<GetDocumentDetailQuery, Response<DocumentDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentDetailHandler(IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }
        public async Task<Response<DocumentDetailsDto>> Handle(GetDocumentDetailQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetByIdAsync(request.id);

            var result = _mapper.Map<DocumentDetailsDto>(document);

            return Response<DocumentDetailsDto>.Success(result);
        }
    }
}
