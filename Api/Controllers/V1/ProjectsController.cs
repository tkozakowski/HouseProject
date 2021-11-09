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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjectsAsync()
        {
            var result = await Mediator.Send(new GetProjectsQuery());

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] CreateProjectDto request)
        {
            return HandleResult<Unit>(await Mediator.Send(new CreateProjectCommand { CreateProjectDto = request}));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateProjectDto request)
        {
            return HandleResult(await Mediator.Send(new UpdateProjectCommand { UpdateProjectDto = request}));
        }

    }
}
