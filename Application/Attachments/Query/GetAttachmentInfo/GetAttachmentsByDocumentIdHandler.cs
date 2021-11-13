using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public class GetAttachmentsByDocumentIdHandler : IRequestHandler<GetApplicatedAttachmentQuery, Result<List<GetAttachmentsByDocumentIdDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAttachmentsByDocumentIdHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAttachmentsByDocumentIdDto>>> Handle(GetApplicatedAttachmentQuery request, CancellationToken cancellationToken)
        {
            var attachmentsDto = await _houseProjectDbContext.Documents
                .Include(x => x.Attachments)
                .Where(x => x.Id == request.documentId)
                .ProjectTo<GetAttachmentsByDocumentIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result<List<GetAttachmentsByDocumentIdDto>>.Success(attachmentsDto);
        }
    }
}
