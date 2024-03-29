﻿using Application.Core;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Command.Add
{
    public class AddSmallFileToDocumentHandler : IRequestHandler<AddSmallFileToDocumentCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddSmallFileToDocumentHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(AddSmallFileToDocumentCommand request, CancellationToken cancellationToken)
        {
            var attachmentSmall = new AttachmentSmall
            {
                DocumentId = request.DocumentId,
                File = request.FormFile.GetBytes(),
                Name = request.FormFile.FileName,
            };

            _houseProjectDbContext.AttachmentsSmall.Add(attachmentSmall);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;          

            if (!success) return Result<Unit>.Failure("Failed to add attachment");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
