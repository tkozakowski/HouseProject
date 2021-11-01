using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<Result<Unit>> Handle(AddExecutionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
