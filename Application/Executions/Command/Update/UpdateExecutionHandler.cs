using Application.Core;
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
    public class UpdateExecutionHandler : IRequestHandler<UpdateExecutionCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public UpdateExecutionHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateExecutionCommand request, CancellationToken cancellationToken)
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
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
