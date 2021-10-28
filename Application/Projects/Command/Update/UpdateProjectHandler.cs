using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Command.Update
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProjectHandler> _logger;

        public UpdateProjectHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, ILogger<UpdateProjectHandler> logger)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _houseProjectDbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.UpdateProjectDto.Id);

            if(project is null)
            {
                _logger.LogDebug($"Response from requested project with id {request.UpdateProjectDto.Id} is null");
                return Result<Unit>.Failure("Failed to update project");
            }

            _mapper.Map(request.UpdateProjectDto, project);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success)
            {
                _logger.LogDebug($"Problem with updating project wiht id {request.UpdateProjectDto.Id}");
                return Result<Unit>.Failure("Failed to update project");
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
