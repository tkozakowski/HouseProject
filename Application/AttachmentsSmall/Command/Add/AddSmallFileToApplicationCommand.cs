﻿using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.AttachmentsSmall.Command.Add
{
    public class AddSmallFileToApplicationCommand : IRequest<Result<Unit>>
    {
        public int ApplicationId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}