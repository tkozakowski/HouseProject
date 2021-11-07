using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoanTranches.Command.Add
{
    public class AddLoanTrancheHandler : IRequestHandler<AddLoanTrancheCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddLoanTrancheHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(AddLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var loanTranche = new LoanTranche
            {
                Amount = request.Amount,
                Stage = (LoanTrancheStage)Enum.Parse(typeof(LoanTrancheStage), request.Stage)
            };

            _houseProjectDbContext.LoanTranches.Add(loanTranche);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success) return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("Failed to add loand tranche");
        }
    }
}
