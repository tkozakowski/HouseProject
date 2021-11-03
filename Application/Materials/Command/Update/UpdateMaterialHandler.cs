using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Cosmonaut.Extensions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Command.Update
{
    public class UpdateMaterialHandler : IRequestHandler<UpdateMaterialCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateMaterialHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = _mapper.Map<Material>(request);

            _houseProjectDbContext.Materials.Update(material);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Publish(new UpdateMaterialEvent(material.Id));
                return Result<Unit>.Success(Unit.Value);
            }
            return Result<Unit>.Failure("Failed to update material");
        }
    }
}
