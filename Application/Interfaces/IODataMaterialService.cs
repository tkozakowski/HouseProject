using Application.Dto.Materials;
using System.Linq;

namespace Application.Interfaces
{
    public interface IODataMaterialService
    {
        public IQueryable<GetMaterialsDto> GetAllMaterials();
    }
}
