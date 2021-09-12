using HouseProject.Application.Core;
using MediatR;

namespace HouseProject.Application.Command.LoanTranches
{
    public class RemoveLoanTrancheCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
