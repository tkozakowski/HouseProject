using Application.Core;
using Application.Dto.Attachments;
using Application.Interfaces;
using Application.Queries.Attachments;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class DownloadAttachmentByIdHandler : IRequestHandler<DownloadAttachmentByIdQuery, Response<DownloadAttachmentDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DownloadAttachmentByIdHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Response<DownloadAttachmentDto>> Handle(DownloadAttachmentByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.Attachments.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var downloadAttachmentDto = new DownloadAttachmentDto
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };

            return Response<DownloadAttachmentDto>.Success(downloadAttachmentDto);
        }
    }
}
