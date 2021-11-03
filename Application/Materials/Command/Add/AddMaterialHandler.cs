using Application.Core;
using Application.Extensions;
using Application.Interfaces;
using Application.Materials.Notification.Add;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Command.Add
{
    public class AddMaterialHandler : IRequestHandler<AddMaterialCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddMaterialHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(AddMaterialCommand request, CancellationToken cancellationToken)
        {

            var material = _mapper.Map<Material>(request.AddMaterialDto);
            material.Photo = request.Photo?.SaveFile();

            _houseProjectDbContext.Materials.Add(material);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Publish(new AddMaterialEvent(request.AddMaterialDto.ExecutionId));
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to add material");
        }
    }
}
