using AutoMapper;
using Application.Command.Documents;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence;

namespace Application.Handlers.Documents
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, Result<Unit>>
    {
        private readonly HouseProjectDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDocumentHandler(HouseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<Unit>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document is null) return null;

            _mapper.Map(request.DocumentDto, document);
            document.UserId = request.UserId;

            var success = await _context.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to update document");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
