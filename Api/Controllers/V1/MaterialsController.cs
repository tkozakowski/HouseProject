using Application.Materials.Command.Add;
using Application.Materials.Query.GetAll;
using Application.Materials.Query.GetDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class MaterialsController : BaseApiController
    {
        public MaterialsController() { }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<GetMaterialsDto>>> GetAll()
        {
            var materials = await Mediator.Send(new GetAllMaterialsQuery());

            return HandleResult(materials);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<GetMaterialDto>> GetDetail(int id)
        {
            var material = await Mediator.Send(new GetMaterialDetailQuery(id));

            return HandleResult(material);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddMaterial([FromQuery] AddMaterialDto materialDto, IFormFile file)
        {
            return HandleResult(await Mediator.Send(new AddMaterialCommand { AddMaterialDto = materialDto, Photo = file }));
        }

    }
}
