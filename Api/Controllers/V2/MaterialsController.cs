using Application.Dto.Materials;
using Application.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IODataMaterialService _materialService;

        public MaterialsController(IODataMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        ///Retrieves all materials in OData protocol
        /// </summary>
        [HttpGet]
        [EnableQuery]
        public IQueryable<GetMaterialsDto> GetAll()
        {
            return _materialService.GetAllMaterials();
        }
    }
}
