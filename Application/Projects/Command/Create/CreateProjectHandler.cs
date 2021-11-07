using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public CreateProjectHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }
        public async Task<Result<Unit>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Project>(request.CreateProjectDto);

            await _houseProjectDbContext.Projects.AddAsync(project);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success)
            {
                return Result<Unit>.Failure("Failed to create project");
            }

            var totalProjectCosts = await _houseProjectDbContext.Projects?.SumAsync(x => x.Cost);
            if (totalProjectCosts != null)
            {
                var finance = await _houseProjectDbContext.Finances.FirstAsync(x => x.Id == 1);
                finance.ProjectsCost = totalProjectCosts;

                await _houseProjectDbContext.SaveChangesAsync();
            }

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
