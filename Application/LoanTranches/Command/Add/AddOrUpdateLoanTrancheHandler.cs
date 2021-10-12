//using Application.Command.LoanTranches;
//using Application.Conversions;
//using Application.Core;
//using AutoMapper;
//using Domain.Entities;
//using Domain.Enum;
//using Domain.Interfaces;
//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.LoanTranches.Command.Add
//{
//    public class AddOrUpdateLoanTrancheHandler : IRequestHandler<AddOrUpdateLoanTrancheCommand, Response<Unit>>
//    {
//        private readonly ILoanTrancheRepository _loanTrancheHandlerRepository;
//        private readonly IMapper _mapper;

//        public AddOrUpdateLoanTrancheHandler(ILoanTrancheRepository loanTrancheHandlerRepository, IMapper mapper)
//        {
//            _loanTrancheHandlerRepository = loanTrancheHandlerRepository;
//            _mapper = mapper;
//        }

//        public async Task<Response<Unit>> Handle(AddOrUpdateLoanTrancheCommand request, CancellationToken cancellationToken)
//        {
//            var stage = StringToEnum.ToEnum<LoanTrancheStage>(request.LoanTrancheDto.Stage, LoanTrancheStage.None);

//            LoanTranche loanTranche = await _loanTrancheHandlerRepository.GetAsync(stage);

//            if (loanTranche is null)
//            {
//                var addLoanTranche = _mapper.Map<LoanTranche>(request.LoanTrancheDto);
//                var addSuccess = await _loanTrancheHandlerRepository.AddAsync(addLoanTranche);

//                if (!addSuccess) return Response<Unit>.Failure("Failed to add new loan tranche");

//                return Response<Unit>.Success(Unit.Value);
//            }

//            loanTranche.Amount = request.LoanTrancheDto.Amount;

//            var updateSuccess = await _loanTrancheHandlerRepository.UpdateAsync(loanTranche); 

//            if (!updateSuccess) return Response<Unit>.Failure("Failed to update loan tranche");

//            return Response<Unit>.Success(Unit.Value);
//        }
//    }
//}
