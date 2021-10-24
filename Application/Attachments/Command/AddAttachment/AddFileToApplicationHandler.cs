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
    public class AddFileToApplicationHandler : IRequestHandler<AddFileToApplicationCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddFileToApplicationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<Unit>> Handle(AddFileToApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _houseProjectDbContext.SendApplications
                .FirstOrDefaultAsync(x => x.Id == request.ApplicationId);

            if (application is null) return null;

            var attachment = new Attachment
            {
                Name = request.File.FileName,
                Application = application,
                Path = request.File.SaveFile()
            };


            _houseProjectDbContext.Attachments.Add(attachment);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to add new attachment");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
