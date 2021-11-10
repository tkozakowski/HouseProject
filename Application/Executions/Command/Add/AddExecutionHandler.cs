using Application.Core;
using Application.Finance.Command.UpdateByExecution;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Executions.Command.Add
{
    public class AddExecutionHandler : IRequestHandler<AddExecutionCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddExecutionHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(AddExecutionCommand request, CancellationToken cancellationToken)
        {
            var execution = _mapper.Map<Execution>(request.AddExecutionDto);

            _houseProjectDbContext.Executions.Add(execution);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                await _mediator.Send(new UpdateByExecutionCommand());

                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to add execution");

        }
    }
}
