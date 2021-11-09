using Application.Core;
using Application.Finance.Command.UpdateByPreparation;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Preparations.Command.Add
{
    public class AddPreparationHandler : IRequestHandler<AddPreparationCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddPreparationHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(AddPreparationCommand request, CancellationToken cancellationToken)
        {
            var preparation = _mapper.Map<Preparation>(request);

            _houseProjectDbContext.Preparations.Add(preparation);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Send(new UpdateByPreparationCommand());

                await _houseProjectDbContext.SaveChangesAsync();
                
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to add preparation");
        }
    }
}
