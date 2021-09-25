using AutoMapper;
using Application.Command.Documents;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Handlers.Documents
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDocumentHandler(IHouseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return null;

            _mapper.Map(request.DocumentDto, document);
            document.UserId = request.UserId;

            var success = await _context.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to update document");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
