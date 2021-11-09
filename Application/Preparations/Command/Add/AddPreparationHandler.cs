using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Preparations.Command.Add
{
    public class AddPreparationHandler : IRequestHandler<AddPreparationCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public AddPreparationHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(AddPreparationCommand request, CancellationToken cancellationToken)
        {
            var preparation = _mapper.Map<Preparation>(request);

            _houseProjectDbContext.Preparations.Add(preparation);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (success)
            {
                var preparationTotalCost = await _houseProjectDbContext.Preparations.SumAsync(x => x.Cost);

                var finance = await _houseProjectDbContext.Finances.FirstAsync(x => x.Id == 1);
                finance.ProjectsCost = preparationTotalCost;

                await _houseProjectDbContext.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to add preparation");
        }
    }
}
