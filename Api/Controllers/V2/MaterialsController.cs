using Application.Interfaces;
using Application.Materials.Query.GetDetail;
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
        public IQueryable<GetMaterialDto> GetAll()
        {
            return _materialService.GetAllMaterials();
        }
    }
}
