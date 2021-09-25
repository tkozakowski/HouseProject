﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Core;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Handlers.Documents
{
    public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, Response<DocumentDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectContext;
        private readonly IMapper _mapper;

        public GetDocumentByIdHandler(IHouseProjectDbContext houseProjectContext, IMapper mapper)
        {
            _houseProjectContext = houseProjectContext;
            _mapper = mapper;
        }
        public async Task<Response<DocumentDto>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectContext.Documents.Where(x => x.Id == request.id)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return Response<DocumentDto>.Success(result);
        }
    }
}
