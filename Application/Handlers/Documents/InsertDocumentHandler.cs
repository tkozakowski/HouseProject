﻿using AutoMapper;
using Application.Command.Documents;
using Application.Core;
using Application.Dto;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Handlers.Documents
{
    public class InsertDocumentHandler : IRequestHandler<InsertDocumentCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectContext;
        private readonly IMapper _mapper;

        public InsertDocumentHandler(IHouseProjectDbContext houseProjectContext, IMapper mapper)
        {
            _houseProjectContext = houseProjectContext;
            _mapper = mapper;
        }
        public async Task<Result<Unit>> Handle(InsertDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Document>(request.documentDto);
            
            document.UserId = request.userId;

            _houseProjectContext.Documents.Add(document);

            var success = await _houseProjectContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to create document");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}