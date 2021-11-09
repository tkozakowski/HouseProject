using Application.Core;
using Application.Finance.Command.Update;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Executions.Command.Update
{
    public class UpdateExecutionCostHandler : IRequestHandler<UpdateExecutionCostCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateExecutionCostHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(UpdateExecutionCostCommand request, CancellationToken cancellationToken)
        {

            var existedExecution = await _houseProjectDbContext.Executions
                .FirstOrDefaultAsync(x => x.Id == request.ExecutionId);

            if (existedExecution is null) return Result<Unit>.Failure("Failed to execute request");

            var execution = _mapper.Map<Execution>(existedExecution);

            var materialsCost = _houseProjectDbContext.Materials
                .Where(x => x.ExecutionId.Value == request.ExecutionId)?
                .Select(x => x.PriceItem * x.Amount)?
                .Sum();

            execution.CostPayed = materialsCost + execution.LaborCost;

            _houseProjectDbContext.Executions.Update(execution);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to update execution");


            var executionTotalCosts = await _houseProjectDbContext.Executions.SumAsync(x => x.CostPayed);
            if (executionTotalCosts != null)
            {
                var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
                finance.ExecutionsCost = executionTotalCosts;

                await _houseProjectDbContext.SaveChangesAsync();
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
