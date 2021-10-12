using Application.Core;
using Application.Dto.LoanTranche;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoanTranches.Query.GetDetail
{
    public class GetLoanTrancheDetailHandler : IRequestHandler<GetLoanTrancheByIdQuery, Response<LoanTrancheDto>>
    {
        private readonly ILoanTrancheRepository _loanTrancheRepository;
        private readonly IMapper _mapper;

        public GetLoanTrancheDetailHandler(ILoanTrancheRepository loanTrancheRepository, IMapper mapper)
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
