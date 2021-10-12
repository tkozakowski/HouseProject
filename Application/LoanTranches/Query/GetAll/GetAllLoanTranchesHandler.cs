using Application.Core;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.Dto.LoanTranche;
using AutoMapper;

namespace Application.LoanTranches.Query.GetAll
{
    public class GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Response<List<LoanTrancheDto>>>
    {
        private readonly ILoanTrancheRepository _loanTrancheRepository;
        private readonly IMapper _mapper;

        public GetAllLoanTranchesHandler(ILoanTrancheRepository loanTrancheRepository, IMapper mapper)
        {
            _loanTrancheRepository = loanTrancheRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<LoanTrancheDto>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            var loanTranches = await _loanTrancheRepository.GetAllAsync();

            var loanTranchesDto = _mapper.Map<List<LoanTrancheDto>>(loanTranches);

            return Response<List<LoanTrancheDto>>.Success(loanTranchesDto);
        }
    }
}
