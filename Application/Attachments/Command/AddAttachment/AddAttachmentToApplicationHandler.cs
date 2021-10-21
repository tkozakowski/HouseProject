using Application.Core;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddAttachmentToApplicationHandler : IRequestHandler<AddAttachmentToApplicationCommand, Response<Unit>>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddAttachmentToApplicationHandler(IMapper mapper, IMediator mediator, IHouseProjectDbContext houseProjectDbContext)
        {
            _mapper = mapper;
            _mediator = mediator;
            _houseProjectDbContext = houseProjectDbContext;
        }


        public async Task<Response<Unit>> Handle(AddAttachmentToApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _houseProjectDbContext.SendApplications.FirstOrDefaultAsync(x => x.Id == request.ApplicationId);

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
