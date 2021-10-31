using Application.Core;
using Application.Interfaces;
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

        public AddMaterialHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(AddMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = _mapper.Map<Material>(request.AddMaterialDto);

            _houseProjectDbContext.Materials.Add(material);
            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to add material");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
