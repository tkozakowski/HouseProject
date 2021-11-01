using Application.Core;
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

        public AddExecutionHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(AddExecutionCommand request, CancellationToken cancellationToken)
        {
            var execution = _mapper.Map<Execution>(request.AddExecutionDto);

            _houseProjectDbContext.Executions.Add(execution);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to add execution");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
