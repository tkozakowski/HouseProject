using Application.Projects.Command.CreateProject;
using Application.Projects.Command.Update;
using Application.Projects.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    [Authorize]
    public class ProjectsController : BaseApiController
    {
        public ProjectsController() { }

        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjects()
        {
            var result = await Mediator.Send(new GetProjectsQuery());

            return HandleResult(result);
        }

        public async Task<IActionResult> Create([FromQuery] CreateProjectDto request)
        {
            return HandleResult<Unit>(await Mediator.Send(new CreateProjectCommand { CreateProjectDto = request}));
        }

        public async Task<IActionResult> Update([FromQuery] UpdateProjectDto request)
        {
            return HandleResult(await Mediator.Send(new UpdateProjectCommand { UpdateProjectDto = request}));
        }

    }
}
