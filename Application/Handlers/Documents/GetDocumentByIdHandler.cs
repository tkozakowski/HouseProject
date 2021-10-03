using AutoMapper;
using Application.Core;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Handlers.Documents
{
    public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, Response<DocumentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentByIdHandler(IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }
        public async Task<Response<DocumentDto>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetByIdAsync(request.id);

            var result = _mapper.Map<DocumentDto>(document);

            return Response<DocumentDto>.Success(result);
        }
    }
}
