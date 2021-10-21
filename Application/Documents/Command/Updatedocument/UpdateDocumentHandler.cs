using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public UpdateDocumentHandler(IMapper mapper, IHouseProjectDbContext houseProjectDbContext)
        {
            _mapper = mapper;
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Response<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingDocument = await _houseProjectDbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existingDocument is null) return null;

            _mapper.Map(request.UpdateDocumentDto, existingDocument);
            existingDocument.UserId = request.UserId;

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to update document");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
