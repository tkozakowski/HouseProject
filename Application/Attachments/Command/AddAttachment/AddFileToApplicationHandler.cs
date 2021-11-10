using Application.Core;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddFileToApplicationHandler : IRequestHandler<AddFileToApplicationCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddFileToApplicationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(AddFileToApplicationCommand request, CancellationToken cancellationToken)
        {
            var document = await _houseProjectDbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.DocumentId);

            if (document is null) return null;

            var attachment = new Attachment
            {
                Name = request.File.FileName,
                Document = document,
                Path = request.File.SaveFile()
            };


            _houseProjectDbContext.Attachments.Add(attachment);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to add new attachment");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
