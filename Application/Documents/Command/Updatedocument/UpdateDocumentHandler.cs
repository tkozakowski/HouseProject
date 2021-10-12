using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Response<Unit>>
    {
        private readonly IDocumentRepository _documentRepository ;
        private readonly IMapper _mapper;

        public UpdateDocumentHandler(IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }
        public async Task<Response<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingDocument = await _documentRepository.GetByIdAsync(request.Id);

            if (existingDocument is null) return null;

            _mapper.Map(request.DocumentDto, existingDocument);
            existingDocument.UserId = request.UserId;

            await _documentRepository.UpdateAsync(existingDocument);

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
