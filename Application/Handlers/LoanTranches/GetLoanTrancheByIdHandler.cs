using Application.Core;
using Application.Dto.LoanTranche;
using Application.Queries.LoanTranches;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class GetLoanTrancheByIdHandler : IRequestHandler<GetLoanTrancheByIdQuery, Response<LoanTrancheDto>>
    {
        private readonly ILoanTrancheRepository _loanTrancheRepository;
        private readonly IMapper _mapper;

        public GetLoanTrancheByIdHandler(ILoanTrancheRepository loanTrancheRepository, IMapper mapper)
        {
            _loanTrancheRepository = loanTrancheRepository;
            _mapper = mapper;
        }

        public async Task<Response<LoanTrancheDto>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            var loanTranche = await _loanTrancheRepository.GetByIdAsync(request.Id);

            if (loanTranche is null) return Response<LoanTrancheDto>.Failure("Failed to get loan tranche");

            var loanTrancheDto = _mapper.Map<LoanTrancheDto>(loanTranche);

            return Response<LoanTrancheDto>.Success(loanTrancheDto);
        }
    }
}
