using Application.Core;
using Application.Finance.Command.UpdateByProject;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProjectHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<Result<Unit>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Project>(request.CreateProjectDto);

            await _houseProjectDbContext.Projects.AddAsync(project);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to create project");

            await _mediator.Send(new UpdateByProjectCommand());

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
