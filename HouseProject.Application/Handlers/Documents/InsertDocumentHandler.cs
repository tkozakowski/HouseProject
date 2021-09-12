using AutoMapper;
using HouseProject.Application.Command.Documents;
using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using HouseProject.Domain.Entities;
using HouseProject.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HouseProject.Application.Handlers.Documents
{
    public class InsertDocumentHandler : IRequestHandler<InsertDocumentCommand, Result<Unit>>
    {
        private readonly HouseProjectDbContext _houseProjectContext;
        private readonly IMapper _mapper;

        public InsertDocumentHandler(HouseProjectDbContext houseProjectContext, IMapper mapper)
        {
            _houseProjectContext = houseProjectContext;
            _mapper = mapper;
        }
        public async Task<Result<Unit>> Handle(InsertDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<DocumentDto, Document>(request.documentDto);

            _houseProjectContext.Documents.Add(document);

            var success = await _houseProjectContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to create document");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
