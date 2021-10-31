using Application.Materials.Command.Add;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{

    public class MaterialsController : BaseApiController
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMaterial([FromQuery] AddMaterialDto materialDto, IFormFile file)
        {
            return HandleResult(await Mediator.Send(new AddMaterialCommand { AddMaterialDto = materialDto, Photo = file }));
        }

    }
}
